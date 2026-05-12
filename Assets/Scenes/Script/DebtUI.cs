using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebtUI : MonoBehaviour
{
    public Text MoneyCount;
    public Text DebtCount;
    public Text TurnCount;
    public Text RoundCount;

    public InputField PayInputField;

    void Update()
    {
        MoneyCount.text =
            GameManager.Instance.money.ToString();

        DebtCount.text =
            GameManager.Instance.debt.ToString();

        TurnCount.text =
            GameManager.Instance.maxTurn.ToString();

        RoundCount.text =
            GameManager.Instance.round.ToString();
    }

    public void PayDebt()
    {
        int pay =
            int.Parse(PayInputField.text);

        // お金減少
        GameManager.Instance.money -= pay;

        // 借金減少
        GameManager.Instance.debt -= pay;

        // 完済チェック
        if (GameManager.Instance.debt <= 0)
        {
            NextRound();
        }
        else
        {
            NextTurn();
        }
    }

    void NextTurn()
    {
        GameManager.Instance.turn++;

        // 制限ターン超え
        if (GameManager.Instance.turn >
           GameManager.Instance.maxTurn)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            SceneManager.LoadScene("PushScene");
        }
    }

    void NextRound()
    {
        GameManager.Instance.round++;

        GameManager.Instance.turn = 1;

        // 次ラウンド借金増加
        GameManager.Instance.debt += 1000;

        SceneManager.LoadScene("PushScene");
    }
}