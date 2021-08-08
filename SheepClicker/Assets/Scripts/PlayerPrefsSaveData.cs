﻿using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerPrefsSaveData : ISaveData
{
    // 所持金のロード
    public BigInteger LoadMoney()
    {
        // PlayerPrefsを使用した場合の所持金ロード処理
        return BigInteger.Parse(PlayerPrefs.GetString("MONEY", "0"));
    }

    // 羊頭数のロード
    public int LoadSheepCnt(int id)
    {
        // PlayerPrefs使用した場合のロード処理
        return PlayerPrefs.GetInt($"SHEEP{id}", 0);
    }

    // 所持金のセーブ
    public void SaveMoney(BigInteger money)
    {
        // PlayerPrefsを使用した場合の所持金セーブ処理
        PlayerPrefs.SetString("MONEY", money.ToString());
    }

    // 羊頭数のセーブ
    public void SaveSheepCnt(int id, int cnt)
    {
        // PlayerPrefsを使用した場合の頭数セーブ処理
        PlayerPrefs.SetInt($"SHEEP{id}", cnt);
    }
}
