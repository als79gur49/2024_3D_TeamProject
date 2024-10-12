using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSoundInit : MonoBehaviour
{
    [SerializeField]
    private string sceneBGMClipName;

    private void Awake()
    {
        string prevBMGClipName = SoundManager.Instance.GetBGMClipName();

        if(SceneManager.GetActiveScene().buildIndex <= 1 && prevBMGClipName == "TitleMenu") //Title, Menu
        {
            //continue
        }
        else
        {
            SoundManager.Instance.StopBGMAudio();

            SoundManager.Instance.PlayBGMAudio(sceneBGMClipName);
        }



    }


}
