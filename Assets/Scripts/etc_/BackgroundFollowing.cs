using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowing : MonoBehaviour
{
    [SerializeField][Range(0,1)]
    private float followingPercent = 1.0f;

    private float mainCameraYAxisDifference;
    private float prevMainCameraYAxis;

    void Update()
    {
        if(prevMainCameraYAxis != Camera.main.transform.position.y)
        {
            mainCameraYAxisDifference = Camera.main.transform.position.y - prevMainCameraYAxis;

            transform.Translate(new Vector3(0, mainCameraYAxisDifference * followingPercent, 0));

            prevMainCameraYAxis = Camera.main.transform.position.y;
        }
    }
}
