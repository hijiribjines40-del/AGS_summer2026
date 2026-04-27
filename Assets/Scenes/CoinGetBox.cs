using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGetBox : MonoBehaviour
{
    public CoinController coinController;
    public AudioSource audioSource;
    public AudioClip SE;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag=="Coin")
        {
            coinController.CoinCount++;
            Destroy(collider.gameObject);
            audioSource.PlayOneShot(SE);
        }
    }
}
