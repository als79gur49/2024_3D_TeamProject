using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBGMInitialize : MonoBehaviour
{
    private static int prevSceneIndex;
    private static int currentSceneIndex;
    [SerializeField]
    private string sceneBGMName;
    private void Awake()
    {
        
    }

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("Main1");
        if (prevSceneIndex <= 1 && currentSceneIndex <= 1) //Title, Menu
        {
            Debug.Log("Main12");
            //continue
        }
        else
        {
            Debug.Log("Main123");
            SoundManager.Instance.PlayBGMAudio(sceneBGMName);
        }

        prevSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
