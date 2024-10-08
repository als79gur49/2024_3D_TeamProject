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

    protected override void BottomCollidedLogic(BlockCollider otherBlock, PlayableMove otherMovement)
    {
        //Debug.Log($"{otherBlock.MainBlock.name}昏力 Side -> Bottom 面倒");
        //TODO: 格见-1
        if (info.PrevGameObject != otherBlock.MainBlock.gameObject)
        {
            SoundManager.Instance.PlayEffectAudio("Fail");
        }
        info.PrevGameObject = otherBlock.MainBlock.gameObject;

        otherBlock.MainBlock.GetComponent<BlockInfo>().DestroyBlock();
    }
    protected override void SideCollidedLogic(BlockCollider otherBlock, PlayableMove otherMovement)
    {
        //Debug.Log($"{otherBlock.MainBlock.name}昏力 Side -> Side 面倒");
        //TODO: 格见-1
        if (info.PrevGameObject != otherBlock.MainBlock.gameObject)
        {
            SoundManager.Instance.PlayEffectAudio("Fail");
        }
        info.PrevGameObject = otherBlock.MainBlock.gameObject;

        otherBlock.MainBlock.GetComponent<BlockInfo>().DestroyBlock();
    }

}
