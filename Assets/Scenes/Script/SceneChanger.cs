using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // どこからでも使えるようにする
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
 //PushSceneからタイトルに戻るボタンを押した時の処理リザルトでは使わない

        //オブジェクトを破棄してゲームをリセットする
        GameManager.Instance.DebtCanvas.SetActive(false);
        Destroy(GameManager.Instance.gameObject);
        GameManager.Instance.ResetGame();

        SceneManager.LoadScene("TitleScene");
    }
}
