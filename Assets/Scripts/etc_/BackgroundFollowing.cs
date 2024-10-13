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
<<<<<<< HEAD
    private float followingPercent = 1.0f;
<<<<<<< HEAD
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
=======
>>>>>>> parent of ed3a944 (test깃허버)

    [SerializeField]
    private Sprite[] skyTextures;
    [SerializeField]
    private Sprite[] cityTextures;
=======
    private float cityFollowingPercent = 1.0f;
>>>>>>> parent of 039c47f (문제 수정중)

    private float mainCameraYAxisDifference;
    private float prevMainCameraYAxis;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< Updated upstream
<<<<<<< HEAD
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
=======
>>>>>>> parent of 8830eeb (내용 병합 및 씬 이동 간 BGM알아서 플레이, 버그 수정)
=======
>>>>>>> parent of 039c47f (문제 수정중)
    private static float test = 5.5f;

    private float rateOfChange00 = 0.0f;
    [SerializeField]
    private float rateOfChange01 = 0.5f;
    [SerializeField]
    private float rateOfChange02 = 0.7f;

=======
>>>>>>> Stashed changes
    void Update()
    {
        if (prevMainCameraYAxis != Camera.main.transform.position.y)
<<<<<<< HEAD
>>>>>>> parent of 8830eeb (내용 병합 및 씬 이동 간 BGM알아서 플레이, 버그 수정)
=======
    void Update()
    {
        if(prevMainCameraYAxis != Camera.main.transform.position.y)
>>>>>>> parent of ed3a944 (test깃허버)
=======
    void Update()
    {
        if(prevMainCameraYAxis != Camera.main.transform.position.y)
>>>>>>> parent of ed3a944 (test깃허버)
=======
>>>>>>> parent of 039c47f (문제 수정중)
        {
            mainCameraYAxisDifference = Camera.main.transform.position.y - prevMainCameraYAxis;

            skyObject?.transform.Translate(new Vector3(0, mainCameraYAxisDifference * skyFollowingPercent, 0));
            cityObject?.transform.Translate(new Vector3(0, mainCameraYAxisDifference * cityFollowingPercent, 0));

            prevMainCameraYAxis = Camera.main.transform.position.y;
        }
    }
}
