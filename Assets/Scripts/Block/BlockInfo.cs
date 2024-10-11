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
        
        Destroy(gameObject);
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