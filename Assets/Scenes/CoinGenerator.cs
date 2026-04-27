using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public CoinController coinController;
    int GoalCoin;
    public int AddCount = 5;
    public int AddCoin = 5;
    public float RandomPos_x = 1;
    //public float MinX = -1.5f;
    //public float MaxX = 1.5f;
    //public float MinZ = -2.2f;
    //public float MaxZ = 2.2f;

    public AudioSource audioSource;
    public AudioClip SE;

    public Transform AddCoinPosition;

   void Start()
   {
        GoalCoin = coinController.CoinCount + AddCount;
   }

   void Update()
   {
        if (coinController.CoinCount >= GoalCoin) 
        {
           // Vector3 basePos = AddCoinPosition.position;

            for (int i = 0; i < AddCoin; i++)
            {
                var pos = AddCoinPosition.position;
                pos.x += Random.Range(-RandomPos_x, RandomPos_x);
                AddCoinPosition.position = pos;

                Instantiate(coinController.Coin,
                    AddCoinPosition.position, Quaternion.identity);
                /*
                //Collider col = coinController.Coin.GetComponent<Collider>();
                //float margin = col.bounds.extents.x;

                //Vector3 spawnPos = basePos;

                //spawnPos.x += Random.Range(-RandomPos_x, RandomPos_x);

                //// 出現元オブジェクトを動かす
                //Vector3 newPos = new Vector3(
                //    basePos.x + spawnPos.x,
                //    basePos.y,
                //    basePos.z+ spawnPos.z
                //);

                //newPos.x = Mathf.Clamp(newPos.x, MinX + margin, MaxX - margin);
                //newPos.z = Mathf.Clamp(newPos.z, MinZ + margin, MaxZ - margin);

                //AddCoinPosition.position = newPos;

                // その位置にコイン生成
                Instantiate(coinController.Coin,
                    AddCoinPosition.position, Quaternion.identity);
                */
                audioSource.PlayOneShot(SE);
            }
            GoalCoin += AddCount;
        }
   }
}
