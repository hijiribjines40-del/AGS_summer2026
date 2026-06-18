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

    //void Start()
    //{

    //}

    void Update()
    {
        Move();

        CoinCountText.text = CoinCount.ToString();

        MoneyText.text = GameManager.Instance.money.ToString();

        if (CoinCount == 0) return;

        if(Input.GetKeyDown(KeyCode.Mouse0))
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
                    Quaternion.Euler(-90, 0, 0));

            // 発射
            var rb = create_coin.GetComponent<Rigidbody>();
            rb.AddForce(CreatePoint.forward *  Power, ForceMode.Impulse);

            // 所持コインを減らす
            CoinCount--;

            // 効果音再生
            audioSource.PlayOneShot(SE);
        }
    }

    void Move()
    {
        /*
        var _speed = Vector3.zero;
        _speed.x = Speed;//0.025

        var pos = this.transform.position;
        if (Input.GetKey(KeyCode.D))
        {
            if (pos.x <= 2)
            {
                this.transform.position += _speed;
            }
            else
            {
                pos.x = 2;
                this.transform.position = pos;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (pos.x >= -2)
            {
                this.transform.position -= _speed;
            }
            else
            {
                pos.x = -2;
                this.transform.position = pos;
            }
        }
        */
        // 横入力取得
        float x = Input.GetAxis("Horizontal");

        // 移動量
        Vector3 move = new Vector3(x * Speed * Time.deltaTime, 0, 0);

        // 移動
        transform.position += move;

        // 範囲制限
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -2f, 2f);

        transform.position = pos;
    }
}
