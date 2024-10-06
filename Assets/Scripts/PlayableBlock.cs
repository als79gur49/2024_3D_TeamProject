using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableBlock : MonoBehaviour
{
    //블럭의 충돌을 담당
    private Transform parentTransform;
    private bool hasConnection = false;

    private PlayableMove playableMove;

    private void Start()
    {
        playableMove = GetComponent<PlayableMove>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsPlayableBlock(collision.gameObject ,out PlayableMove block))
        {   //자신은 멈춘 상태 && 상대는 움직이는 상태
            Debug.Log("collision is playable");

            if (!IsFalling(this.playableMove) && IsFalling(block))
            {//top - bottom o, top - side x, side - bottom x, side- side x
                Debug.Log("NotMovingContact");
                Debug.Log(LayerMask.LayerToName(collision.gameObject.layer));
                if (collision.gameObject.layer.Equals(BlockManager.bottomLayer))
                {
                    Debug.Log("collision is bottomLayer");
                    Debug.Log(LayerMask.LayerToName(collision.gameObject.layer));

                    if (hasConnection)
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
                        Camera.main.GetComponent<CameraController>()?.SetCameraPosition();
                    }
                }
            }
        }
    }

    private bool IsPlayableBlock(GameObject obj, out PlayableMove block)
    {
        block = null;

        return obj.GetComponent<PlayableBlock>() && obj.TryGetComponent<PlayableMove>(out block);
    }

    private bool IsFalling(PlayableMove block)
    {
        return block.IsMoving && block.IsFalling;
    }

}

/*
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
 */ 