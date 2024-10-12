using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public void GoToMenu()
    {
        // 메뉴 씬으로 이동
        SceneManager.LoadScene("Menu");
    }
}
