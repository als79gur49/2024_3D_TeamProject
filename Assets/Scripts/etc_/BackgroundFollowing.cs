using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundFollowing : MonoBehaviour
{
    [SerializeField]
    private GameObject skyObject;
    [SerializeField]
    private GameObject cityObject;

    [SerializeField][Range(0, 1)]
    private float skyFollowingPercent = 1.0f;
    [SerializeField][Range(0,1)]
    private float cityFollowingPercent = 1.0f;

    [SerializeField]
    private Sprite[] skyTextures;
    [SerializeField]
    private Sprite[] cityTextures;

    private float mainCameraYAxisDifference;
    private float prevMainCameraYAxis;


    private float rateOfChange00 = 0.0f;
    [SerializeField]
    private float rateOfChange01 = 0.5f;
    [SerializeField]
    private float rateOfChange02 = 0.7f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            changeBackground(10, 10);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            changeBackground(4, 10);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            changeBackground(2, 10);
        }

        if (prevMainCameraYAxis != Camera.main.transform.position.y)
        {
            mainCameraYAxisDifference = Camera.main.transform.position.y - prevMainCameraYAxis;

            skyObject?.transform.Translate(new Vector3(0, mainCameraYAxisDifference * skyFollowingPercent, 0));
            cityObject?.transform.Translate(new Vector3(0, mainCameraYAxisDifference * cityFollowingPercent, 0));

            prevMainCameraYAxis = Camera.main.transform.position.y;
        }
    }

    void changeBackground(float timeLimit, float max)
    {
        float rate = (max - timeLimit) / max;

        if(rate >= rateOfChange02)
        {
            skyObject.GetComponent<Image>().sprite = skyTextures[2];
            cityObject.GetComponent<Image>().sprite = cityTextures[2];
        }
        else if(rate >= rateOfChange01)
        {
            skyObject.GetComponent<Image>().sprite = skyTextures[1];
            cityObject.GetComponent<Image>().sprite = cityTextures[1];
        }
        else if(rate >= rateOfChange00)
        {
            skyObject.GetComponent<Image>().sprite = skyTextures[0];
            cityObject.GetComponent<Image>().sprite = cityTextures[0];
        }
    }
}
