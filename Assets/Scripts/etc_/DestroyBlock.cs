using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    //Collider가 자식에게 존재, PlayableMove는 부모에게 존재
    Transform parentTransform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        parentTransform = collision.transform.parent;
        //Playable && bool이지만 Playable이 유용한 객체이면 true, 그렇지 않으면 false를 평가하기에 작동하는 듯
        if (collision.gameObject.GetComponent<PlayableBlock>()  &&
            parentTransform.TryGetComponent<PlayableMove>(out PlayableMove block))
        {
            if(block.IsMoving)
            {
                Destroy(collision.gameObject);
                //Destroy
            }
        }

    }
}
