using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sheepRenderer;
    [SerializeField]
    private Sprite cutSheepSprite;
    [SerializeField]
    private Wool woolPrefab;

    // 最初の羊の画像
    private Sprite defaultSprite;

    // 移動速度
    private float moveSpeed;

    // 羊の初期データ
    public SheepData sheepData;

    // 羊毛の量
    private int woolCnt;

    // Start is called before the first frame update
    void Start()
    {
        defaultSprite = sheepRenderer.sprite;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed, 0) * Time.deltaTime;
        if(transform.position.x < -5)
        {
            Initialize();
        }
    }

    private void Shaving()
    {
        if (woolCnt <= 0) return; // もう刈り取れる羊毛はないので何もしない。
        // 今羊に残っている羊毛と30-40%の羊毛のうち少ない量を刈り取る。
        var shavingWool = (int)Mathf.Min(woolCnt, sheepData.woolCnt * Random.Range(0.3f, 0.4f));

        woolCnt -= shavingWool; // 今回刈り取る分を保持している羊毛から減らし
        if(woolCnt <= 0) // 0になったようなら、
        {
            sheepRenderer.sprite = cutSheepSprite; // 画像をカットされたものに差し替え
            sheepRenderer.color = Color.white; // 毛はもうないので色を白に戻す。
            SoundManager.Instance.Play("メー");
        }
        var wool = Instantiate(woolPrefab, transform.position, transform.rotation);
        // Woolオブジェクトに今回刈り取った羊毛と色情報を渡す。
        wool.price = shavingWool;
        wool.woolColor = sheepData.color;
        SoundManager.Instance.Play("刈り取り");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) == false) return;
        Shaving();
    }

    // 初期化処理
    private void Initialize()
    {
        sheepRenderer.sprite = defaultSprite;
        // 初期位置をセット
        transform.position = new Vector3(5, Random.Range(0.0f,4.0f), 0);
        //移動速度をセット
        moveSpeed = -Random.Range(1.0f, 2.0f);

        // 色のセット
        sheepRenderer.color = sheepData.color;
        // 羊毛の量
        woolCnt = sheepData.woolCnt;
    }
}
