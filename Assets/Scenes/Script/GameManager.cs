using UnityEngine;

public class GameManager : MonoBehaviour
{
    // どこからでも使えるようにする
    public static GameManager Instance;

    // お金
    public int money;

    // 基本借金
    public int baseDebt = 1000;

    // 借金
    public int debt = 1000;

    // ラウンド
    public int round = 1;

    // 最大ラウンド
    public int maxRound = 3;

    //ターン
    public int turn = 1;

    //最大ターン
    public int maxTurn = 3;

    private void Awake()
    {
        // すでに存在していたら消す
        if (Instance == null)
        {
            Instance = this;

            // シーンを切り替えても消えない
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetGame()
    {
        money = 0;

        baseDebt = 30;

        debt = 30;

        round = 1;

        turn = 1;
    }
}
