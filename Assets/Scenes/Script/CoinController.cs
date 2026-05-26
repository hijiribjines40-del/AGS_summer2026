using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public GameObject Coin;
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
            var create_coin =
                Instantiate(Coin, CreatePoint.position, Quaternion.identity);
            var rb = create_coin.GetComponent<Rigidbody>();
            rb.AddForce(CreatePoint.forward *  Power, ForceMode.Impulse);
            CoinCount--;
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
        // â°ì¸óÕéÊìæ
        float x = Input.GetAxis("Horizontal");

        // à⁄ìÆó 
        Vector3 move = new Vector3(x * Speed * Time.deltaTime, 0, 0);

        // à⁄ìÆ
        transform.position += move;

        // îÕàÕêßå¿
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -2f, 2f);

        transform.position = pos;
    }
}
