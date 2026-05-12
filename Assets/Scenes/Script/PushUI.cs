using UnityEngine;
using UnityEngine.UI;

public class PushUI : MonoBehaviour
{
    public Text CoinNumberText;
    public Text MoneyNumberText;
    public Text DebtNumberText;
    public Text MaxTurnCount;
    public Text TurnCount;
    public Text RoundNumberText;
    public Text TimeCount;

    public CoinController coinController;

    void Update()
    {
        CoinNumberText.text =
            coinController.CoinCount.ToString();

        MoneyNumberText.text =
            GameManager.Instance.money.ToString();

        DebtNumberText.text =
            GameManager.Instance.debt.ToString();

        MaxTurnCount.text =
            $"{GameManager.Instance.maxTurn} - {GameManager.Instance.turn}";

        /*TurnCount.text =
            GameManager.Instance.turn.ToString();
        */
        RoundNumberText.text =
            GameManager.Instance.round.ToString();
    }
}
