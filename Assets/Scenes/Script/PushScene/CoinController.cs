using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    // コインPrefabを複数登録
    public GameObject[] Coin;
    public Transform CreatePoint;
    public float Power;

    public float Speed;

    public int CoinCount;
    public Text CoinCountText;

    public Text MoneyText;

    public AudioSource audioSource;
    public AudioClip SE;

    // コイン発射時のX座標の移動範囲
    public const float MOVE_MIN_X = -2f;
    public const float MOVE_MAX_X = 2f;

    // コイン生成時の回転角度
    public static readonly Vector3 COIN_ROTATION = new Vector3(-90f, 0f, 0f);

    void Update()
    {
        Move();

        CoinCountText.text = CoinCount.ToString();

        MoneyText.text = GameManager.Instance.money.ToString();

        if (CoinCount == 0) return;

        if (GameManager.Instance.DebtCanvas.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Prefabが登録されていなければ終了
                if (Coin.Length == 0) return;

                // ランダムにPrefabを選ぶ
                int randomIndex = Random.Range(0, Coin.Length);

                // 選んだPrefabを生成
                var create_coin =
                    Instantiate(
                        Coin[randomIndex],
                        CreatePoint.position,
                        Quaternion.Euler(COIN_ROTATION));

                // 発射
                var rb = create_coin.GetComponent<Rigidbody>();
                rb.AddForce(CreatePoint.forward * Power, ForceMode.Impulse);

                // 所持コインを減らす
                CoinCount--;

                // 効果音再生
                audioSource.PlayOneShot(SE);

            }
        }
    }

    void Move()
    {
   
        // 横入力取得
        float x = Input.GetAxisRaw("Horizontal");

        // 移動量
        Vector3 move = new Vector3(x * Speed * Time.deltaTime, 0, 0);

        // 移動
        transform.position += move;

        // 範囲制限
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, MOVE_MIN_X, MOVE_MAX_X);

        transform.position = pos;
    }
}
