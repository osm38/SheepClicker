using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wool : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    // 羊毛の売却価格
    public int price = 100;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D.AddForce(Quaternion.Euler(0, 0, Random.Range(-15.0f, 15.0f)) * Vector2.up * 4, ForceMode2D.Impulse);
        transform.localScale = Vector3.one * Random.Range(0.4f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    // 羊毛の売却処理
    public void Shell(Wallet wallet)
    {
        wallet.money += price;
        Destroy(gameObject);
    }
}
