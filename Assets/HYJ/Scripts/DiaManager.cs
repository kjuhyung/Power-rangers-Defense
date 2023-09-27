using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DiaManager : MonoBehaviour
{
    public TMP_Text diaText;

    public int currentDiamons = 0;// 현재 다이아 양

    void Start()
    {
        LoadDiamonds();
        UpdateDiaUI();
    }

    public void StageCleared(int reward)
    {
        currentDiamons += reward;
        SaveDiamons();
        UpdateDiaUI();
    }

    void UpdateDiaUI()
    {
        diaText.text = ($"{currentDiamons}");
    }

    void SaveDiamons()
    {
        PlayerPrefs.SetInt("Diamonds", currentDiamons);
        PlayerPrefs.Save();
    }

    void LoadDiamonds()
    {
        currentDiamons = PlayerPrefs.GetInt("Diamonds", 0);
    }

}
