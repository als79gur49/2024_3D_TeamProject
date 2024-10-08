using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockCollider : MonoBehaviour
{
    //Top -> Bottom 2개 이상 쌓이면 모두 삭제 0
    // Top->Side side오브젝트만 삭제
    //Side->Bottom 상대 오브젝트 삭제
    //Side->Side 상대 오브젝트 삭제

    [SerializeField]
    protected GameObject mainBlock;
    protected PlayableMove movement;
    protected BlockInfo info;

    public GameObject MainBlock { get => mainBlock; set => mainBlock = value; }

    protected virtual void Start()
    {
        movement = mainBlock.GetComponent<PlayableMove>();
        info = mainBlock.GetComponent<BlockInfo>();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPlayableBlock(other.gameObject, out BlockCollider otherBlock, out PlayableMove otherMovement) &&
           !IsFalling(movement) && IsFalling(otherMovement) && 
           MainBlock != otherBlock.MainBlock)
        {
            if (other.GetComponent<BottomBlockCollider>())
            {
                BottomCollidedLogic(otherBlock, otherMovement);
            }
            else if (other.GetComponent<SideBlockCollider>())
            {
                SideCollidedLogic(otherBlock, otherMovement);
            }
            else if (other.GetComponent<TopBlockCollider>())
            {

            }
        }
    }

    protected virtual void BottomCollidedLogic(BlockCollider otherBlock, PlayableMove otherMovement) { }
    protected virtual void SideCollidedLogic(BlockCollider otherBlock, PlayableMove otherMovement) { }


    private bool IsPlayableBlock(GameObject obj, out BlockCollider collide, out PlayableMove block)
    {
        BlockCollider blockCollide = obj.GetComponent<BlockCollider>();
        block = null;

        return (obj.TryGetComponent<BlockCollider>(out collide) && 
               blockCollide.MainBlock.TryGetComponent<PlayableMove>(out block));
    }

    private bool IsFalling(PlayableMove block)
    {
        return block.IsMoving && block.IsFalling;
    }
}