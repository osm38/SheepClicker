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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
