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
        sheepRenderer.sprite = cutSheepSprite;
        var wool = Instantiate(woolPrefab, transform.position, transform.rotation);
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
    }
}
