using System.Collections;
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    // メダルPrefab複数
    public GameObject[] medalPrefabs;

    // メダル生成位置
    public Transform spawnPoint;

    // 落下範囲
    public float rangeX = 5f;

    IEnumerator Start()
    {
        int result = 500;

        // GameManagerがある時
        if (GameManager.Instance != null)
        {
            result = GameManager.Instance.money;
        }

        int count = 0;

        while (count <= result)
        {
            // 数字更新
            resultText.text =
                "獲得メダル : " + count;

            // メダル生成
            CreateMedal();

            count++;

            yield return new WaitForSeconds(0.01f);
        }
    }

    void CreateMedal()
    {
        Debug.Log("Length : " + medalPrefabs.Length);

        if (medalPrefabs.Length == 0)
        {
            Debug.Log("Prefabが入ってない");
            return;
        }

        int randomIndex =
            Random.Range(0, medalPrefabs.Length);

        Debug.Log("Index : " + randomIndex);

        GameObject randomMedal =
            medalPrefabs[randomIndex];

        if (randomMedal == null)
        {
            Debug.Log("PrefabがNone");
            return;
        }

        Vector3 pos =
            spawnPoint.position;

        pos.x += Random.Range(-rangeX, rangeX);

        Instantiate(
            randomMedal,
            pos,
            Random.rotation);
    }
}