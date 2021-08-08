using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // 購入ボタンプレハブ
    [SerializeField]
    private SheepButton sheepButtonPrefab;

    // 生成元になる羊データ配列
    public SheepData[] sheepDatas;

    // 作成したSheepButtonをListで保持
    public List<SheepButton> sheepButtonList;

    // SheepButtonにセットする羊生成オブジェクト
    [SerializeField]
    private SheepGenerator sheepGenerator;

    // SheepButtonにセットする羊生成オブジェクト
    [SerializeField]
    private Wallet wallet;

    void Awake()
    {
        // 受け取ったSheepData配列の数だけSheepButtonを作成
        foreach(var sheepData in sheepDatas)
        {
            // transformを指定することで子要素に生成
            var sheepButton = Instantiate(sheepButtonPrefab, transform);
            sheepButton.sheepData = sheepData;
            sheepButtonList.Add(sheepButton);
            sheepButton.sheepGenerator = sheepGenerator;
            sheepButton.wallet = wallet;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
