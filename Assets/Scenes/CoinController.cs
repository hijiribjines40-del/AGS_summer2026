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
    public AudioSource audioSource;
    public AudioClip SE;

    //void Start()
    //{

    //}

    void Update()
    {
        Move();

        CoinCountText.text = CoinCount.ToString();

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
        var _speed = Vector3.zero;
        _speed.x = Speed;

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
    }
}
