using System.Collections;
using UnityEngine;

public class SceneButton : MonoBehaviour
{
    public AudioSource audioSource;  // 효과음을 재생할 오디오 소스
    public AudioClip buttonClickSound;  // 클릭 시 재생할 효과음

    public ChangeScenes changeScenes;

    


    public float waitTimeMultiplier = 1.0f;  


    public void PlaySoundAndChangeScene()
    {
        StartCoroutine(PlaySoundAndTriggerSceneChange());
    }

    private IEnumerator PlaySoundAndTriggerSceneChange()
    {
      
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);

            // 효과음 길이의 일부만큼 대기 (전체 재생시간 * waitTimeMultiplier)
            yield return new WaitForSeconds(buttonClickSound.length * waitTimeMultiplier);
        }

        // ChangeScenes 스크립트의 Load() 메서드를 호출하여 씬을 전환합니다.
        if (changeScenes != null)
        {
            changeScenes.Load();
        }
    }
}
