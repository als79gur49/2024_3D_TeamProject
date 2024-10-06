using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    [SerializeField]
    private AudioMixer mAudioMixer;

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
            mAudioMixer.SetFloat("Master", currentMasterVolume);
        }
    }
    public float BGMVolume
    {
        get => currentBGMVolume;
        set => currentBGMVolume = Mathf.Clamp(value, -80, 20);
    }
    public float EffectVolume
    {
        get => currentEffectVolume;
        set => currentEffectVolume = Mathf.Clamp(value, -80, 20);
    }

    public AudioClip[] clips;

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



    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);

            return;
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayAudio(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            PlayAudio(clips[0]);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAudio(clips[1]);
        }
    }

}
