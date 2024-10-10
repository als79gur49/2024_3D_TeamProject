using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public LevelLock levelLock; // LevelLock 스크립트 참조

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        levelLock = FindObjectOfType<LevelLock>(); // LevelLock 찾기
        if (levelLock == null)
        {
            Debug.LogWarning("LevelLock not found in the scene.");
        }
    }

    public void StageClear(int stageIndex)
    {
        Debug.Log($"StageClear called for stage {stageIndex}");

        if (levelLock != null)
        {
            levelLock.MarkStageClear(stageIndex);
            Debug.Log("MarkStageClear called.");
        }


        int levelReached = PlayerPrefs.GetInt("levelReached", 0); // 현재 레벨 불러오기
        int nextStage = levelReached + 1;

        Debug.Log($"Current levelReached: {levelReached}, NextStage: {nextStage}");

        // 다음 스테이지 락 해제
        if (levelLock != null)
        {
            levelLock.UnlockNextStage();
            Debug.Log("UnlockNextStage called.");
        }

        // 다음 스테이지 번호 저장
        PlayerPrefs.SetInt("levelReached", nextStage);
        PlayerPrefs.Save();

        Debug.Log($"Stage {nextStage} unlocked and saved.");

    }
        



}
