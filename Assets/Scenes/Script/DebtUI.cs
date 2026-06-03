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

        int remainTurn =
            GameManager.Instance.maxTurn - 
            GameManager.Instance.turn;

        TurnCount.text =
            remainTurn.ToString();

        if (remainTurn <= 1) // 残り1ターン
        {
            TurnCount.color =
                new Color(
                    1,
                    Mathf.Abs(Mathf.Sin(Time.time * 5)),
                    Mathf.Abs(Mathf.Sin(Time.time * 5))
                );
        }

        RoundCount.text =
            GameManager.Instance.round.ToString();
    }

    public void PayDebt()
    {
        int pay =
            int.Parse(PayInputField.text);

        // 所持金以上は支払えない
        if (pay > GameManager.Instance.money)
        {
            Debug.Log("所持金が足りません");
            return;
        }

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
            GameOver();
        }
        else
        {
            SceneManager.LoadScene("PushScene");
        }
    }

    void NextRound()
    {
        GameManager.Instance.round++;
        // 制限ラウンド超え
        if (GameManager.Instance.round >
           GameManager.Instance.maxRound)
        {
            // 完済チェック
            if (GameManager.Instance.debt <= 0)
            {
                GameClear();
            }
            else
            {
                GameOver();
            }
        }
        else
        {
            GameManager.Instance.turn = 1;

            // 次Roundの借金増加
            GameManager.Instance.baseDebt += debtAdd;

            // 現在借金に追加
            GameManager.Instance.debt +=
                GameManager.Instance.baseDebt;

            SceneManager.LoadScene("PushScene");
        }
    }

    void GameOver()
    {
        GameManager.Instance.ResetGame();

        SceneManager.LoadScene("GameOverScene");
    }

    void GameClear()
    {
        GameManager.Instance.ResetGame();

        SceneManager.LoadScene("ClearScene");
    }
}