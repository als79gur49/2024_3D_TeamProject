using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowing : MonoBehaviour
{
    [SerializeField][Range(0,1)]
    private float followingPercent = 1.0f;
<<<<<<< HEAD

    [SerializeField]
    private Sprite[] skyTextures;
    [SerializeField]
    private Sprite[] cityTextures;

    [SerializeField]
    private Sprite[] skyTextures;
    [SerializeField]
    private Sprite[] cityTextures;

    [SerializeField]
    private Sprite[] skyTextures;
    [SerializeField]
    private Sprite[] cityTextures;

    [SerializeField]
    private Sprite[] skyTextures;
    [SerializeField]
    private Sprite[] cityTextures;
=======
>>>>>>> parent of ed3a944 (test깃허버)

    [SerializeField]
    private Sprite[] skyTextures;
    [SerializeField]
    private Sprite[] cityTextures;

    private float mainCameraYAxisDifference;
    private float prevMainCameraYAxis;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    void Update()
    {
        if(prevMainCameraYAxis != Camera.main.transform.position.y)
=======
=======
>>>>>>> parent of 8830eeb (내용 병합 및 씬 이동 간 BGM알아서 플레이, 버그 수정)
=======
>>>>>>> parent of 8830eeb (내용 병합 및 씬 이동 간 BGM알아서 플레이, 버그 수정)
>>>>>>> Stashed changes
=======
>>>>>>> parent of 8830eeb (내용 병합 및 씬 이동 간 BGM알아서 플레이, 버그 수정)
    private static float test = 5.5f;

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
>>>>>>> parent of 8830eeb (내용 병합 및 씬 이동 간 BGM알아서 플레이, 버그 수정)
=======
    void Update()
    {
        if(prevMainCameraYAxis != Camera.main.transform.position.y)
>>>>>>> parent of ed3a944 (test깃허버)
        {
            mainCameraYAxisDifference = Camera.main.transform.position.y - prevMainCameraYAxis;

            transform.Translate(new Vector3(0, mainCameraYAxisDifference * followingPercent, 0));

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
