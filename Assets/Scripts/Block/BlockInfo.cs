using UnityEngine;

public class BlockInfo : MonoBehaviour
{
    [SerializeField]
    private int maxInteractableBlock = 1;
    //자신의 위에 최대 붙을 수 있는 블럭의 개수;

    [SerializeField][Range(0, 500)]
    private int score;

    public int Score { get => score; }

    [SerializeField]
    private int interactableBlock = 0;
    public int MaxInteractableBlock { get => maxInteractableBlock;}
    public int InteractableBlock { get => interactableBlock; set => interactableBlock = value; }

    public GameObject PrevGameObject { get; set; }

    public void DestroyBlock()
    {
<<<<<<< Updated upstream
        //TODO:블럭 삭제 함수 소리, 파티클 등 추가하기
=======
        if(SoundManager.Instance.EffectPlayer.GetComponent<AudioSource>().isPlaying)
        {
            SoundManager.Instance.PlayEffectAudio("Fail", 0.4f);
        }
        else
        {
            SoundManager.Instance.PlayEffectAudio("Fail");
        }

        AdditionalCondition();
>>>>>>> Stashed changes

        Destroy(gameObject);
    }
}

<<<<<<< Updated upstream
//삭제 시 애니메이션 이용해서 삭제
//성공 시 파티클, 실패 시 파티클
=======
    private void AdditionalCondition()
    {
        if(GetComponentInChildren<SpriteRenderer>()?.sprite.name == "Object_00_02")
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
>>>>>>> Stashed changes
