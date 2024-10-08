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
        //TODO:블럭 삭제 함수 소리, 파티클 등 추가하기

        Destroy(gameObject);
    }
}

//삭제 시 애니메이션 이용해서 삭제
//성공 시 파티클, 실패 시 파티클