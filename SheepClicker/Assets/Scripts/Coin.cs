using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // 加算する金額
    public int value;

    // Walletオブジェクト 目的地権、加算対象
    public Wallet wallet;

    // 移動待ち時間
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        // 0.1秒～0.3秒のランダム
        waitTime = Random.Range(0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        // カウントダウン
        waitTime -= Time.deltaTime;
        // まだ待ち時間なので動かない。
        if (waitTime > 0) return;
        // 現在の位置から、Walletオブジェクトまで進むベクトル
        var v = wallet.transform.position - transform.position;
        transform.position += v * Time.deltaTime * 20;

        // 近づいたら到着したとみなす
        if (v.magnitude < 0.5f)
        {
            wallet.money += value;
            Destroy(gameObject);
        }
    }
}
