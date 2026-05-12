using UnityEngine;
using UnityEngine.SceneManagement;

public class PushSceneManager : MonoBehaviour
{
    public float timer = 30f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene("DebtScene");
        }
    }
}
