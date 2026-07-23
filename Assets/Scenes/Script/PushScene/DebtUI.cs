using UnityEngine;
using UnityEngine.InputSystem;
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

    public GameObject DebtCanvas;
    public PushSceneManager pushSceneManager;

    private PlayerInputActions inputActions;

    public int addMoney = 1;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Repayment.Enable();

        inputActions.Repayment.Increase.performed += IncreasePay;
        inputActions.Repayment.Decrease.performed += DecreasePay;
        inputActions.Repayment.Confirm.performed += ConfirmPay;
    }

    private void OnDisable()
    {
        inputActions.Repayment.Increase.performed -= IncreasePay;
        inputActions.Repayment.Decrease.performed -= DecreasePay;
        inputActions.Repayment.Confirm.performed -= ConfirmPay;

        inputActions.Repayment.Disable();
    }

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

        //デバッグ用、スペースキーでゲームオーバー画面に遷移
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // GameSceneへ移動
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            // GameSceneへ移動
            GameClear();
        }
    }

    // ⑤ 入力処理
    private void IncreasePay(InputAction.CallbackContext ctx)
    {
        int pay = 0;

        int.TryParse(PayInputField.text, out pay);

        pay += addMoney;

        if (pay > GameManager.Instance.money)
            pay = GameManager.Instance.money;

        if (pay > GameManager.Instance.debt)
            pay = GameManager.Instance.debt;

        PayInputField.text = pay.ToString();
    }

    private void DecreasePay(InputAction.CallbackContext ctx)
    {
        int pay = 0;

        int.TryParse(PayInputField.text, out pay);

        pay -= addMoney;

        if (pay < 0)
            pay = 0;

        PayInputField.text = pay.ToString();
    }

    private void ConfirmPay(InputAction.CallbackContext ctx)
    {
        PayDebt();
    }

    public void PayDebt()
    {
        // 入力が数字かどうかチェック outからint payの宣言
        if (!int.TryParse(PayInputField.text, out int pay))
        {
            Debug.Log("数字を入力してください");
            PayInputField.text = "";
            return;
        }
        //int pay =
        //    int.Parse(PayInputField.text);

        int originalPay = pay;

        // 所持金を超えたら所持金と同数にする
        if (pay > GameManager.Instance.money)
        {
            pay = GameManager.Instance.money;
        }

        // 借金を超えたら借金額にする
        if (pay > GameManager.Instance.debt)
        {
            pay = GameManager.Instance.debt;
        }

        // 補正が発生したら表示だけ更新して終了
        if (pay != originalPay)
        {
            PayInputField.text = pay.ToString();
            return;
        }

        //// 所持金以上は支払えない
        //if (pay > GameManager.Instance.money)
        //{
        //    Debug.Log("所持金が足りません");
        //    return;
        //}

        // ここから実際の返済
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
            pushSceneManager.timer = pushSceneManager.Bestimer;

            Time.timeScale = 1;

            DebtCanvas.SetActive(false);
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

            pushSceneManager.timer = pushSceneManager.Bestimer;

            Time.timeScale = 1;

            GameManager.Instance.DebtCanvas.SetActive(false);
        }
    }

    void GameOver()
    {
       
        SceneManager.LoadScene("GameOverScene");
    }

    void GameClear()
    {

        SceneManager.LoadScene("ClearScene");
    }
}