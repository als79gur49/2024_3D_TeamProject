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

                SoundManager.Instance.PlayEffectAudio("Success");

                Camera.main.GetComponent<CameraController>()?.SetCameraPosition();
            }
        }
        else
        {
            if(info.PrevGameObject != otherBlock.MainBlock.gameObject)
            {
                BlockManager.DestroyAllBlocks();

                otherBlock.MainBlock.GetComponent<BlockInfo>().DestroyBlock();
                StageManager.Instance.CurrentHealth--;
            }
            info.PrevGameObject = otherBlock.MainBlock.gameObject;
        }
    }
    protected override void SideCollidedLogic(BlockCollider otherBlock, PlayableMove otherMovement)
    {
        if (info.PrevGameObject != otherBlock.MainBlock.gameObject)
        {
            otherBlock.MainBlock.GetComponent<BlockInfo>().DestroyBlock();
            StageManager.Instance.CurrentHealth--;
        }
        info.PrevGameObject = otherBlock.MainBlock.gameObject;     
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

/* //소리 출력 원형
if(info.PrevGameObject != otherBlock.MainBlock.gameObject)
            {
                //SoundManager.Instance.PlayEffectAudio("Fail");
            }
            info.PrevGameObject = otherBlock.MainBlock.gameObject;

            otherBlock.MainBlock.GetComponent<BlockInfo>().DestroyBlock();
            BlockManager.DestroyAllBlocks();
*/