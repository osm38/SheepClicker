using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    public SheepData sheepData;

    public SheepGenerator sheepGenerator;

    // 羊画像
    [SerializeField]
    private Image sheepImage;

    // 金額Text
    [SerializeField]
    private Text priceText;

    // 頭数Text
    [SerializeField]
    private Text countText;

    // 販売可否Text
    [SerializeField]
    private Text infoText;

    // 所持金オブジェクト
    public Wallet wallet;

    // 現在の頭数
    public int currentCnt;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(CreateSheep);
    }

    // Update is called once per frame
    void Update()
    {
        var price = GetPrice();

        // 羊の色をセット
        sheepImage.color = sheepData.color;
        // 金額表示なので通貨書式"C0"を指定
        priceText.text = price.ToString("C0");
        // 現在の頭数と上限表示
        countText.text = $"{currentCnt}頭 / {sheepData.maxCount}頭";

        // 購入上限の場合
        if(currentCnt >= sheepData.maxCount)
        {
            infoText.text = "完売";
            button.interactable = false; // ボタン無効化
        }
        // 購入可能
        else if(wallet.money >= price)
        {
            infoText.text = "購入";
            button.interactable = true; // ボタン有効化
        }
        // 所持金不足
        else
        {
            infoText.text = "お金が足りません";
            button.interactable = false; // ボタン無効化
        }
    }

    public void CreateSheep()
    {
        sheepGenerator.CreateSheep(sheepData);
        var price = GetPrice();
        wallet.money -= price; // 購入した分所持金からマイナス
        currentCnt++; // 現在の頭数をインクリメント
    }

    // 現在の羊の金額を返却
    public int GetPrice()
    {
        // 現在の頭数から、次の購入金額を計算
        return sheepData.basePrice + sheepData.extendPrice * currentCnt;
    }
}
