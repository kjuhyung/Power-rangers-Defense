using UnityEngine;
using TMPro;

public class DiaManager : MonoBehaviour
{
    public TMP_Text diaText;

    private int currentDiamons;

    void Start()
    {       
        LoadDiamonds();        
    }

    private void LateUpdate()
    {
        diaText.text = ($"{currentDiamons}");
    }

    public void StageCleared(int reward)
    {
        int amount = currentDiamons + reward;
        SaveDiamons(amount);        
    }

    void SaveDiamons(int amount)
    {
        PlayerPrefs.SetInt("Diamonds", amount);
        PlayerPrefs.Save();

        LoadDiamonds();
    }

    void LoadDiamonds()
    {
        currentDiamons = PlayerPrefs.GetInt("Diamonds");
    }

}
