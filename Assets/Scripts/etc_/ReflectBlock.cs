using System.Collections.Generic;
using UnityEngine;

public class ReflectBlock : MonoBehaviour
{
    //Collider가 자식에게 존재, PlayableMove는 부모에게 존재
    Transform parentTransform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        parentTransform = collision.transform.parent;
    
        if (parentTransform ?.TryGetComponent<PlayableMove>(out PlayableMove block) ?? false)
        {
            block.HorizontalReflect();
        }
    }

}
