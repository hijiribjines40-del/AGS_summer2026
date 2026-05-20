using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
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

}
