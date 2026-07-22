using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // どこからでも使えるようにする
    public static SceneChanger Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GoToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void GoToDebtScene()
    {
        SceneManager.LoadScene("DebtScene");
    }

    public void GoToPushScene()
    {
        SceneManager.LoadScene("PushScene");
    }

    public void GoToClearScene()
    {
        SceneManager.LoadScene("ClearScene");
    }
    public void GoToGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void GoToReturnScen()
    {
        //オブジェクトを破棄してゲームをリセットする
        GameManager.Instance.DebtCanvas.SetActive(false);
        Destroy(GameManager.Instance.gameObject);
        GameManager.Instance.ResetGame();

        SceneManager.LoadScene("TitleScene");
    }
}
