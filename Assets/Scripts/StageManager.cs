using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : MonoBehaviour
{
    //각 스테이지별로 배치, 클리어 조건 설정, 게임 성공 및 실패 호출 하는 곳
    //CurrentHeight프로퍼티는 GameClear, CurrentHealth프로퍼티는 GameFail

    //[SerializeField]
    //private int currentStageLevel;

    [Header("일정 높이 이상")]
    [SerializeField]
    private bool targetOnOffSwitch;
    [SerializeField]
    [Range(0, 500)]
    private int targetHeight;

    [SerializeField]
    private int currentHeight;
    [SerializeField]
    private int currentHealth;


    public delegate void ChangedHealth(int currenthealth);
    public static event ChangedHealth OnHealthChanged;


    public int CurrentHeight
    {
        get => currentHeight;

        set
        {
            currentHeight = value;

            if (currentHeight >= targetHeight && targetOnOffSwitch)
            {
                InGameUI inGameUI = FindAnyObjectByType<InGameUI>();
                if (inGameUI != null)
                {
                    inGameUI.gameClear();
                }
                Debug.Log("Game Clear");
            }
        }
    }
    public int CurrentHealth
    {
        get => currentHealth;

        set
        {
            currentHealth = value;

            OnHealthChanged?.Invoke(currentHealth);
            if (currentHealth <= 0)
            {
                InGameUI inGameUI = FindAnyObjectByType<InGameUI>();
                if (inGameUI != null)
                {
                    inGameUI.gameOver();
                }
                Debug.Log("Game Fail");
            }
        }
    }

    public int TargetHeight
    {
        get => targetHeight;
    }

    public bool TargetOnOffSwitch
    {
        get => targetOnOffSwitch;
    }

    private static StageManager instance;
    public static StageManager Instance
    {
        get
        {
            if (instance == null) //Awake이전 호출 시, 초기화
            {
                instance = FindObjectOfType<StageManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("StageManager");
                    instance = obj.AddComponent<StageManager>();

                    //DontDestroyOnLoad(obj);
                }
            }

            return instance;
        }
    }

    



    private void Awake() //싱글톤 패턴
    {
        BlockManager.ResetBlocks();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);

            return;
        }

        instance = this;

        //DontDestroyOnLoad(this.gameObject);
    }

}
