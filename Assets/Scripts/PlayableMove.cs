using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableMove : MonoBehaviour
{
    // 좌우 이동 및 상하 이동 담당
    [SerializeField][Range(0, 10)]
    private float horizontalSpeed;
    [SerializeField][Range(0, 10)]
    private float verticalSpeed;
    [SerializeField]
    private bool isAccelerating; //필요 여부에 따라 차후 제작 가능.

    public float HorizontalSpeed { get => horizontalSpeed; set { horizontalSpeed = value; } }
    public float VerticalSpeed { get => verticalSpeed; set {  verticalSpeed = value; } }

    private Vector2 nextPosition;
    private int horizontalDirection;

    void Start()
    {
        nextPosition = transform.position;
        horizontalDirection = 1;
    }

    void Update()
    {
        Moving();
        
    }

    private void Moving()
    {
        nextPosition.x += horizontalDirection * HorizontalSpeed * Time.deltaTime;
        //벽에서 OnTrigger 통해 PlayableMove,Block 있으면 hordirection값 * -1 하기 <- 해야할것
        if (isAccelerating)
        {
            // 미사용
        }
        else
        {
            nextPosition.y -= VerticalSpeed * Time.deltaTime;
        }

        transform.position = nextPosition;
        nextPosition = transform.position;
    }
}
