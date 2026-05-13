using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebtUI : MonoBehaviour
{
    public Text MoneyCount;
    public Text DebtCount;
    public Text TurnCount;
    public Text RoundCount;

    // 借金の加算
    public int debtAdd;
    public InputField PayInputField;

    void Update()
    {
        MoneyCount.text =
            GameManager.Instance.money.ToString();

        DebtCount.text =
            GameManager.Instance.debt.ToString();

        TurnCount.text =
            $"{GameManager.Instance.maxTurn - GameManager.Instance.turn}";

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

        // 次Roundの借金増加
        GameManager.Instance.baseDebt += debtAdd;

        // 現在借金に追加
        GameManager.Instance.debt +=
            GameManager.Instance.baseDebt;

        SceneManager.LoadScene("PushScene");
    }
}