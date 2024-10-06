using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class ReflectBlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<BlockCollider>(out BlockCollider block))
        {
            block.MainBlock.GetComponent<PlayableMove>()?.HorizontalReflect();
            Debug.Log($"{block.MainBlock.name}반사 좌우벽 충돌");
        }
    }

}
