using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockManager : MonoBehaviour
{
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
            Destroy(block);
            //한 번에 삭제가 아닌 순차적 삭제 필요 시 코루틴 이용하기
            
        }
        Camera.main.GetComponent<CameraController>().SetCameraPosition();
    }
}
