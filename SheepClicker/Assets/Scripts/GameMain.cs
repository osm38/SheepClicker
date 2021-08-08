using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    private Button sellButton;
    [SerializeField]
    private Wallet wallet;
    // Start is called before the first frame update
    void Start()
    {
        sellButton.onClick.AddListener(SellAllWool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SellAllWool()
    {
        // 画面上の全てのWoolスクリプトが付いたオブジェクトを検索してwools配列に格納。
        var wools = FindObjectsOfType<Wool>();
        foreach(var wool in wools)
        {
            wool.Sell(wallet);
        }
    }
}
