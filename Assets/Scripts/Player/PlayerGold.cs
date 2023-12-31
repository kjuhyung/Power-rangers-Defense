using UnityEngine;
using TMPro;

public class PlayerGold : MonoBehaviour
{
   
    public int currentGold = 0; // 처음 주어질 골드의 양 

    public TMP_Text goldText;

    void Start()
    {
        currentGold = 1000;
    }

    public void AddGold(int amount)
    {
        currentGold += amount; // 몬스터가 죽으면 나올 골드를 더해준다        
    }

    private void LateUpdate()
    {
        goldText.text = currentGold + " G";
    }
}
