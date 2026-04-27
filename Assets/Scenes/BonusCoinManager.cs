using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BonusCoinManager : MonoBehaviour
{
    public CoinController coinController;
    public CoinGenerator coinGenerator;
    public Vector2 BonusRange;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            var AddCount = Random.RandomRange(BonusRange.x, BonusRange.y);
            for (int i = 0; i < AddCount; i++)
            {
                var pos = coinGenerator.AddCoinPosition.position;
                pos.x += Random.Range(-coinGenerator.RandomPos_x, coinGenerator.RandomPos_x);
                coinGenerator.AddCoinPosition.position = pos;

                Instantiate(coinController.Coin,
                    coinGenerator.AddCoinPosition.position, Quaternion.identity);
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
                coinGenerator.audioSource.PlayOneShot(coinGenerator.SE);
            }
        }
    }
}
