using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


[System.Serializable]
public class KeyValuePair
{
    public string name;
    public AudioClip clip;

    public static implicit operator AudioClip(KeyValuePair pair)
    {
        return pair.clip;
    }
}

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mAudioMixer;
    [SerializeField]
    private GameObject bgmPlayer;
    [SerializeField]
    private GameObject effectPlayer;

    public GameObject EffectPlayer => effectPlayer;

    #region 볼륨 수정하는 변수들
    [SerializeField][Range(-80, 20)]
    private float currentMasterVolume;
    [SerializeField][Range(-80, 20)]
    private float currentBGMVolume;
    [SerializeField][Range(-80, 20)]
    private float currentEffectVolume;

    public float MasterVolume
    {
        get => currentMasterVolume;
        set
        {
            currentMasterVolume = Mathf.Clamp(value, -80, 20);
            mAudioMixer.SetFloat("MasterVolume", currentMasterVolume);
        }
    }
    public float BGMVolume
    {
        get => currentBGMVolume;
        set
        {
            currentBGMVolume = Mathf.Clamp(value, -80, 20);
            mAudioMixer.SetFloat("BGMVolume", currentBGMVolume);
        }
    }
    public float EffectVolume
    {
        get => currentEffectVolume;
        set
        {
            currentEffectVolume = Mathf.Clamp(value, -80, 20);
            mAudioMixer.SetFloat("EffectVolume", currentEffectVolume);
        }
    }
    #endregion

    [SerializeField]
    private List<KeyValuePair> bgmClips;
    [SerializeField]
    private List<KeyValuePair> effectClips;


    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null) //Awake이전 호출 시, 초기화
            {
                instance = FindObjectOfType<SoundManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("SoundManager");
                    instance = obj.AddComponent<SoundManager>();

                    DontDestroyOnLoad(obj);
                }
            }

            return instance;
        }
    }

    private void OnValidate() //인스펙터 창에서 값 수정 시 호출되는 함수
    {
        MasterVolume = currentMasterVolume;
        BGMVolume = currentBGMVolume;
        EffectVolume = EffectVolume;
    }
    private void Awake() //싱글톤 패턴, 씬로드 시 추가코드
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);

            return;
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);


        SceneManager.sceneLoaded += OnSceneLoaded;
    }



    public void PlayBGMAudio(AudioClip clip)
    {
        bgmPlayer.GetComponent<AudioSource>().clip = clip;

        bgmPlayer.GetComponent<AudioSource>().Play();
    }
    public bool PlayBGMAudio(string clipName)
    {
        AudioClip resultClip = GetClip(clipName, bgmClips);

        if (resultClip == null)
        {
            Debug.Log($"BGMSound에서 {clipName}을 찾을 수 없습니다.");

            return false;
        }

        bgmPlayer.GetComponent<AudioSource>().clip = resultClip;
        bgmPlayer.GetComponent<AudioSource>().Play();

        return true;
    }
    public bool PlayBGMAudio(string clipName, out AudioClip audioClip)
    {
        audioClip = GetClip(clipName, effectClips);

        if (audioClip == null)
        {
            Debug.Log($"BGMSound에서 {clipName}을 찾을 수 없습니다.");

            return false;
        }

        bgmPlayer.GetComponent<AudioSource>().clip = audioClip;
        bgmPlayer.GetComponent<AudioSource>().Play();

        return true;
    }

    public void PlayEffectAudio(AudioClip clip)
    {
        effectPlayer.GetComponent<AudioSource>().PlayOneShot(clip);
    }
    public bool PlayEffectAudio(string clipName, float volume = 1f)
    {
        AudioClip resultClip = GetClip(clipName, effectClips);

        if (resultClip == null)
        {
            Debug.Log($"EffectSound에서 {clipName}을 찾을 수 없습니다.");

            return false;
        }

        effectPlayer.GetComponent<AudioSource>().PlayOneShot(resultClip, volume);

        return true;
    }
    public bool PlayEffectAudio(string clipName, out AudioClip audioClip)
    {
        audioClip = GetClip(clipName, effectClips);

        if (audioClip == null)
        {
            Debug.Log($"EffectSound에서 {clipName}을 찾을 수 없습니다.");

            return false;
        }

        effectPlayer.GetComponent<AudioSource>().PlayOneShot(audioClip);

        return true;
    }

    private AudioClip GetClip(string name, List<KeyValuePair> list)
    {
        foreach (KeyValuePair pair in list)
        {
            if (pair.name == name)
            {
                return pair.clip;
            }
        }

        return null;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //다음 씬 로드시, 해당 씬에 사운드매니저가 존재한다면, 해당 사운드매니저의 초기값으로 초기화되고 삭제되어서
        //변수들 강제 할당해주기

        MasterVolume += 0;
        BGMVolume += 0;
        EffectVolume += 0;
    }
}
