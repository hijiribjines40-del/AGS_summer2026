using System.Collections;
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    IEnumerator Start()
    {
        if (resultText == null)
        {
            Debug.LogError("resultText ‚ª“ü‚Á‚Ä‚¢‚Ü‚¹‚ñ");
            yield break;
        }

        int result = 500;

        if (GameManager.Instance != null)
        {
            result = GameManager.Instance.money;
        }

        int count = 0;

        while (count <= result)
        {
            resultText.text =
                "Šl“¾ƒRƒCƒ“ : " + count;

            count++;

            yield return new WaitForSeconds(0.01f);
        }
    }
}