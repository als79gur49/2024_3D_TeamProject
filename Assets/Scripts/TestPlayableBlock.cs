using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayableBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject mainBlock;
    private bool hasConnection = false;

    private PlayableMove mainPlayableMove;
    private void Start()
    {
        mainPlayableMove = mainBlock.GetComponent<PlayableMove>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayableBlock(collision.gameObject, out PlayableMove block))
        {   //자신은 멈춘 상태 && 상대는 움직이는 상태
            if (!IsFalling(mainPlayableMove) && IsFalling(block))
            {//top - bottom o, top - side x, side - bottom x, side- side x
                if (collision.gameObject.layer.Equals(BlockManager.bottomLayer))
                {
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

