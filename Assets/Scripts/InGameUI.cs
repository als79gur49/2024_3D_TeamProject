using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public GameObject gameClearUI;
    public GameObject gameOverUI;
    public GameObject tutorialImage;
    public TextMeshProUGUI clearTimeText;
   
    public GameObject timeTextObject; 
    private Text Texttime;
    Timer timer;

    private GameManager gameManager;
    public int stageIndex;
   
    void Start()
    {  
            timer = GetComponent<Timer>();
            if (timer == null) Debug.Log("timeCnt is null");

            if (timeTextObject != null)
            {
                Texttime = timeTextObject.GetComponent<Text>();
                if (Texttime == null)
                {
                Debug.Log("Text component is not attached to the timeTextObject");
                }
            }
            else
            {
                Debug.Log("timeTextObject is null");
            }


        float bestTime = PlayerPrefs.GetFloat("BestTime", 0.0f);
        Debug.Log("Best time:" + bestTime);


        gameManager = FindObjectOfType<GameManager>();  // GameManager 참조
        if (gameManager == null)
        {
            Debug.LogWarning("GameManager not found in the scene.");
        }

    }


    void Update()
    {
        Debug.Log("Update is called");

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("InactiveImage", 0.25f);
        }


        if( Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("gameClear called");
            gameClear();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            gameOver();
        }

        if (Texttime == null)
        {
            Debug.Log("timeText is null");
            return;
        }

        {
   
            if (timer != null && timer.gameTime >= 0.0f)
            {

                int hours = (int)timer.displayTime / 3600;
                int minutes = ((int)timer.displayTime % 3600) / 60;
                int seconds = (int)timer.displayTime % 60;
                int milliseconds = (int)((timer.displayTime - Mathf.Floor(timer.displayTime)) * 1000);

                if (Texttime != null)
                { 
                    Texttime.text = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", hours, minutes, seconds, milliseconds);
                }
            }
        }




    }

    void gameClear()
    {
        timer.StopTimer();
        Debug.Log($"Calling SaveBestTime with displayTime: {timer.displayTime} and stageIndex: {stageIndex}");
        SaveBestTime(timer.displayTime, stageIndex); // stageIndex를 올바르게 전달
        if (gameClearUI != null)
        {
            gameClearUI.SetActive(true);
        }

        if (clearTimeText != null)
        {
            float clearTime = timer.displayTime;
            int hours = (int)clearTime / 3600;
            int minutes = ((int)clearTime % 3600) / 60;
            int seconds = (int)clearTime % 60;
            int milliseconds = (int)((clearTime - Mathf.Floor(clearTime)) * 1000);

            clearTimeText.text = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", hours, minutes, seconds, milliseconds);
        }

        if (gameManager != null)
        {
            Debug.Log($"Calling StageClear with stageIndex: {stageIndex}");

            // GameManager의 StageClear 메서드 호출
            gameManager.StageClear(stageIndex);
        }
    }


    void SaveBestTime(float time, int stageIndex)
    {
        Debug.Log($"SaveBestTime called for stage {stageIndex} with time: {time}");
        float bestTime = PlayerPrefs.GetFloat($"BestTime_{stageIndex}", float.MaxValue);
        Debug.Log($"Current best time for stage {stageIndex}: {bestTime}");

        if (time < bestTime)
        {
            PlayerPrefs.SetFloat($"BestTime_{stageIndex}", time);
            PlayerPrefs.Save();
            Debug.Log($"New best Time for stage {stageIndex}: {time} saved in PlayerPrefs");
        }
        else
        {
            Debug.Log($"No new best time set for stage {stageIndex}");
        }
    }




    void gameOver()
    {
        timer.StopTimer();
        if(gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }
    void InactiveImage()
    {
        tutorialImage.SetActive(false);
    }
}
