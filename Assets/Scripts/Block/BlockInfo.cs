using System.Collections;
using UnityEngine;

public class BlockInfo : MonoBehaviour
{
    [SerializeField]
    private int maxInteractableBlock = 1;
    //자신의 위에 최대 붙을 수 있는 블럭의 개수;

    [SerializeField][Range(0, 20)]
    private int height;

    public int Height { get => height; }

    private int interactableBlock = 0;
    public int MaxInteractableBlock { get => maxInteractableBlock;}
    public int InteractableBlock { get => interactableBlock; set => interactableBlock = value; }

    public GameObject PrevGameObject { get; set; }
    //블럭이 움직이는 방법
    //좌우 이동 -> Input -> 상하 이동 -> 다른 블럭과 접촉 시 조건에 따라 삭제 or 설치
    //설치 시 고정 -> 오차 수정위해 설정된 위치로 조정

    public void DestroyBlock()
    {
        if(SoundManager.Instance.EffectPlayer.GetComponent<AudioSource>().isPlaying)
        {
            SoundManager.Instance.PlayEffectAudio("Fail", 0.4f);
        }
        else
        {
            SoundManager.Instance.PlayEffectAudio("Fail");
        }

        AdditionalCondition();

        Destroy(gameObject);
    }

    private void AdditionalCondition()
    {
        if(GetComponentInChildren<SpriteRenderer>().sprite.name == "Object_00_02")
        {
            Debug.Log("노란색 블럭 삭제");
            StageManager.Instance.CurrentHealth = 0;
        }
    }

    public void DelayDestroyBlock(float delayTime)
    {
        StartCoroutine(ChangeColor(delayTime));
    }

    private IEnumerator ChangeColor(float duration)
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

        Color originColor = sprite.color;

        sprite.color = Color.red;
        yield return new WaitForSeconds(duration);

        sprite.color = originColor;

        DestroyBlock();
    }    


}