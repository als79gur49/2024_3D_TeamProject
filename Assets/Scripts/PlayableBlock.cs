using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableBlock : MonoBehaviour
{
    //충돌 관련 코드
    private Transform parentTransform;
    private bool hasConnection = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayableBlock>() &&
           collision.gameObject.TryGetComponent<PlayableMove>(out PlayableMove block))
        {
            if(block.IsMoving && block.IsFalling)
            {
                if(hasConnection)
                {
                    Destroy(collision.gameObject);
                    Debug.Log($"2개 이상 쌓여 {collision.gameObject.name} 삭제");
                }
                else
                {
                    hasConnection = true;
                    block.StopBlock();
                    BlockManager.PushBlock(collision.gameObject);
                    //AddScore
                    Camera.main.GetComponent<CameraController>().SetCameraPosition();
                }
            }
        }
    }
}
