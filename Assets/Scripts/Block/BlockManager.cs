using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockManager : MonoBehaviour
{
    //블럭 저장 및 처리

    private static Stack<GameObject> blocks = new Stack<GameObject>();
    public static Stack<GameObject> Blocks {  get { return blocks; }  private set { blocks = value; } }

    public static int BlocksHeight { get; private set; } = 0;

    public static void PushBlock(GameObject block)
    {
        Blocks.Push(block);

        SetBlocksHeight();
    }

    public static void DestroyAllBlocks()
    {
        while(Blocks.TryPop(out GameObject block))
        {
            Debug.Log("Deleted");

            block?.GetComponent<BlockInfo>()?.DestroyBlock();
            //한 번에 삭제가 아닌 순차적 삭제 필요 시 코루틴 이용하기
            
        }

        SetBlocksHeight();
        Camera.main.GetComponent<CameraController>().SetCameraPosition();
    }

    public static void SetBlocksHeight()
    {
        BlocksHeight = 0;

        foreach(GameObject block in Blocks)
        {
            BlocksHeight += block?.GetComponent<BlockInfo>().Height ?? 0;
        }

        StageManager.Instance.CurrentHeight = BlocksHeight;

        Debug.Log($"재설정된 블럭높이:{BlocksHeight}");
    }

}
