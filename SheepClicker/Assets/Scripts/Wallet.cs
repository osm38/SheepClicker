using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public BigInteger money;

    [SerializeField]
    private Text walletText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        walletText.text = money.ToString("C0");
    }
}
