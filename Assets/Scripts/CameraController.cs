using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private int blockLimit;
    private int blockCount;

    [SerializeField]
    private Transform originPosition;

    [SerializeField][Range(-5,5)]
    private float additionalYAxis;
    [SerializeField][Range(1,10)]
    private float moveSpeed; //카메라가 움직이지 않을 경우 인스펙터 창에서 값 바꿔보기

    private float currentHeight;
    private float targetHeight;
    private float time;
    void Start()
    {
        blockCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        blockCount = BlockManager.Blocks.Count;
        //나중에 블럭들이 Push, Pop될 경우에만 Count변경시키기 

        MoveCameraPosition();
    }

    private void MoveCameraPosition()
    {
        time = Mathf.Clamp01(time + (Time.deltaTime * moveSpeed));

        transform.position = new Vector3(0, Mathf.Lerp(currentHeight, targetHeight, time), -10);
    }
    public void SetCameraPosition()
    {
        time = 0f;
        currentHeight = transform.position.y;

        if (blockLimit > blockCount)
        {
            targetHeight = originPosition.position.y;
        }
        else
        {
            targetHeight = BlockManager.Blocks.Peek().transform.position.y + additionalYAxis;
        }
    }
}
