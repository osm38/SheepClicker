using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGenerator : MonoBehaviour
{
    [SerializeField]
    private Sheep sheepPrefab;

    // 羊作成
    public void CreateSheep(SheepData sheepData)
    {
        var sheep = Instantiate(sheepPrefab);
        sheep.sheepData = sheepData;
    }
}
