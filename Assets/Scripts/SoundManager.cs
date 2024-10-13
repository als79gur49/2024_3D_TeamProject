using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    private GameObject BGMPlayer;
    [SerializeField]
    private GameObject EffectPlayer;

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
            if(instance == null) //Awake이전 호출 시, 초기화
            {
                instance = FindObjectOfType<SoundManager>();

                if(instance == null)
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
    private void Awake() //싱글톤 패턴
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);

            return;
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayBGMAudio(AudioClip clip)
    {
        BGMPlayer.GetComponent<AudioSource>().clip = clip;

        BGMPlayer.GetComponent<AudioSource>().Play();
    }

    public void PlayBGMAudio(string clipName)
    {
        AudioClip resultClip = GetClip(clipName, bgmClips);

        BGMPlayer.GetComponent<AudioSource>().clip = resultClip;

        BGMPlayer.GetComponent<AudioSource>().Play();
    }

    public void PlayEffectAudio(AudioClip clip)
    {
        EffectPlayer.GetComponent<AudioSource>().PlayOneShot(clip);
    }

    public void PlayEffectAudio(string clipName)
    {
        AudioClip resultClip = GetClip(clipName, effectClips);

        EffectPlayer.GetComponent<AudioSource>().PlayOneShot(resultClip);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            PlayBGMAudio(GetClip("Test", bgmClips));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayEffectAudio(effectClips[0]);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayEffectAudio("Test");
        }
    }

<<<<<<< Updated upstream
    public AudioClip GetClip(string name, List<KeyValuePair> list)
=======
    public void StopBGMAudio()
    {
        effectPlayer.GetComponent<AudioSource>().Stop();
    }

    private AudioClip GetClip(string name, List<KeyValuePair> list)
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

=======
    //GetBGMClipName
>>>>>>> Stashed changes
    private string GetClipName(AudioClip clip, List<KeyValuePair> list)
    {
        foreach (KeyValuePair pair in list)
        {
            if (pair.clip == clip)
            {
                return pair.name;
            }
        }

        return null;
    }

<<<<<<< Updated upstream
    public string GetBGMClipName()
    {
        return GetClipName(bgmPlayer.GetComponent<AudioSource>().clip, bgmClips);
=======
    public string CurrentBGMName()
    {
        AudioClip clip = bgmPlayer.GetComponent<AudioSource>().clip;

        return GetClipName(clip, bgmClips);
>>>>>>> Stashed changes
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //다음 씬 로드시, 해당 씬에 사운드매니저가 존재한다면, 해당 사운드매니저의 초기값으로 초기화되고 삭제되어서
        //변수들 강제 할당해주기

        MasterVolume += 0;
        BGMVolume += 0;
        EffectVolume += 0;
    }
>>>>>>> Stashed changes
}
