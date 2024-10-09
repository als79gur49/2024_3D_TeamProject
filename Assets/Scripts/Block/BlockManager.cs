using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockManager : MonoBehaviour
{
    //블럭 레이어, 블럭 저장 및 처리

    public static readonly LayerMask bottomLayer = 1 << 9;
    public static readonly LayerMask topLayer = 1 << 10;
    public static readonly LayerMask sideLayer = 1 << 11;

    private static Stack<GameObject> blocks = new Stack<GameObject>();
    public static Stack<GameObject> Blocks {  get { return blocks; }  private set { blocks = value; } }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            DestroyAllBlocks();
        }
    }

    public static void PushBlock(GameObject block)
    {
        Blocks.Push(block);
    }

    public static void DestroyAllBlocks()
    {
        while(Blocks.TryPop(out GameObject block))
        {
            Debug.Log("Deleted");

            block?.GetComponent<BlockInfo>()?.DestroyBlock();
            //한 번에 삭제가 아닌 순차적 삭제 필요 시 코루틴 이용하기
            
        }
        Camera.main.GetComponent<CameraController>().SetCameraPosition();
    }
}
