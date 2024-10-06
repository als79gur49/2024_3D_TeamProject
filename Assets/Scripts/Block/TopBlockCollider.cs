using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBlockCollider : BlockCollider
{
    protected List<GameObject> collidedBlocks = new List<GameObject>();
    protected override void Start()
    {
        base.Start();
    }

    protected override void BottomCollidedLogic(BlockCollider otherBlock, PlayableMove otherMovement)
    {
        if (collidedBlocks.Count < info.MaxInteractableBlock)
        {
            if (AddList(otherBlock, otherMovement))
            {
                otherMovement.StopBlock();
                BlockManager.PushBlock(otherBlock.MainBlock);

                //TODO:: AddScore
                Camera.main.GetComponent<CameraController>()?.SetCameraPosition();
            }
        }
        else
        {
            //Debug.Log($"{otherBlock.MainBlock.name}삭제 Top -> Bottom 충돌");
            otherBlock.MainBlock.GetComponent<BlockInfo>().DestroyBlock();
            //TODO: 목숨 -1 && 모든 블럭 삭제

            BlockManager.DestroyAllBlocks();
        }
    }
    protected override void SideCollidedLogic(BlockCollider otherBlock, PlayableMove otherMovement)
    {
        Debug.Log($"{otherBlock.MainBlock.name}삭제 Top -> Side 충돌");
        //TODO: 목숨-1
        otherBlock.MainBlock.GetComponent<BlockInfo>().DestroyBlock();
    }

    private bool AddList(BlockCollider otherBlock, PlayableMove otherMovement)
    {
        if (!collidedBlocks.Contains(otherBlock.MainBlock))
        {
            Debug.Log("리스트에 추가" + otherBlock.MainBlock.name);
            collidedBlocks.Add(otherBlock.MainBlock);

            MainBlock.GetComponent<BlockInfo>().InteractableBlock++;

            return true;
        }

        return false;
    }
    protected void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.TryGetComponent<BlockCollider>(out BlockCollider block))
        {
            if (collidedBlocks.Contains(block.MainBlock))
            {
                Debug.Log("리스트에 삭제" + block.MainBlock.name);
                collidedBlocks.Remove(block.MainBlock);
                MainBlock.GetComponent<BlockInfo>().InteractableBlock--;
            }
        }
    }
}
