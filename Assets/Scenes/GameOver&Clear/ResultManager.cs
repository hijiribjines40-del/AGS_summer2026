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

    // 総獲得メダル数
    public int result;

    // リザルト画面開始時の時間倍率
    public const float RESULT_TIME_SCALE = 1f;

    // GameManagerが取得できなかった場合に使用するリザルトの初期値
    public const int DEFAULT_RESULT = 500;

    // リザルトのメダルを1枚ずつ生成する間隔（秒）
    public const float RESULT_INTERVAL = 0.01f;

    IEnumerator Start()
    {
        Time.timeScale = RESULT_TIME_SCALE;
        Debug.Log("result = " + result);
        Debug.Log("totalmoney = " + GameManager.Instance.totalmoney);
        Debug.Log("timeScale = " + Time.timeScale);
        result = DEFAULT_RESULT;

        // GameManagerがある時
        if (GameManager.Instance != null)
        {
            result = GameManager.Instance.totalmoney;
        }

        int count = 0;

        while (count <= result)
        {
            // 数字更新
            resultText.text =
                "総獲得メダル : " + count;

            // メダル生成
            CreateMedal();

            Debug.Log("count = " + count);
            count++;

            yield return new WaitForSeconds(RESULT_INTERVAL);
            Debug.Log("CreateMedal");
        }
    }


    void CreateMedal()
    {
        // 配列に入っているPrefabの数を表示（デバッグ用）
        Debug.Log("Length : " + medalPrefabs.Length);

        // Prefabが1つも登録されていない場合は終了
        if (medalPrefabs.Length == 0)
        {
            Debug.Log("Prefabが入ってない");
            return;
        }

        // 配列の中からランダムに1つ選ぶ
        int randomIndex =
            Random.Range(0, medalPrefabs.Length);

        // 選ばれた番号を表示（デバッグ用）
        Debug.Log("Index : " + randomIndex);

        // ランダムに選ばれたPrefabを取得
        GameObject randomMedal =
            medalPrefabs[randomIndex];

        // 選ばれたPrefabが設定されていない場合は終了
        if (randomMedal == null)
        {
            Debug.Log("PrefabがNone");
            return;
        }

        // SpawnPointの位置を取得
        Vector3 pos =
            spawnPoint.position;

        // X座標をランダムにずらして、
        // メダルがばらついて落ちるようにする
        pos.x += Random.Range(-rangeX, rangeX);

        // メダルを生成
        // 位置：pos
        // 向き：ランダム
        Debug.Log("Instantiate");
        Instantiate(
            randomMedal,
            pos,
            Random.rotation);
    }
}