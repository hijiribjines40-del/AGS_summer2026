using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToDebtScene()
    {
        SceneManager.LoadScene("DebtScene");
    }

    public void GoToPushScene()
    {
        SceneManager.LoadScene("PushScene");
    }
}
