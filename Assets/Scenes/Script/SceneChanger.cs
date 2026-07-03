using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // ‚Ç‚±‚©‚ç‚Å‚àŽg‚¦‚é‚æ‚¤‚É‚·‚é
    public static SceneChanger Instance;
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
        GameManager.Instance.ResetGame();

        SceneManager.LoadScene("TitleScene");
    }
}
