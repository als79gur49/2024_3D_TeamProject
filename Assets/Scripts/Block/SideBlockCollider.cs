using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBlockCollider : BlockCollider
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    //Side->Bottom 상대 오브젝트 삭제
    //Side->Side 상대 오브젝트 삭제
    protected override void BottomCollidedLogic(BlockCollider otherBlock, PlayableMove otherMovement)
    {
        Debug.Log($"{otherBlock.MainBlock.name}삭제 Side -> Bottom 충돌");
        //TODO: 목숨-1
        otherBlock.MainBlock.GetComponent<BlockInfo>().DestroyBlock();
    }
    protected override void SideCollidedLogic(BlockCollider otherBlock, PlayableMove otherMovement)
    {
        //Debug.Log($"{otherBlock.MainBlock.name}삭제 Side -> Side 충돌");
        //TODO: 목숨-1
        otherBlock.MainBlock.GetComponent<BlockInfo>().DestroyBlock();
    }

}
