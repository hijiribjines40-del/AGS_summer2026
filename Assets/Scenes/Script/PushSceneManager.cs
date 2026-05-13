using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PushSceneManager : MonoBehaviour
{
    public float timer = 30f;
    public Text TimerText;

    void Update()
    {
        timer -= Time.deltaTime;

        // ¬”‚ğÁ‚µ‚Ä•\¦
        TimerText.text =
           Mathf.Ceil(timer).ToString();

        // ŠÔØ‚ê
        if (timer <= 0)
        {
            SceneManager.LoadScene("DebtScene");
        }
    }
}
