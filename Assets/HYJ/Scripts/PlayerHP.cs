using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 5; // 플레이어 목숨 (타워 벽에 몬스터 닿을 시 줄어드는)
    public int currentHP;

    public GameObject PlayerHpPrefab;
    public Transform PlayerHpPos; // 부모 캔버스 Grid Layout Group 이용 

    private List<GameObject> hpImages = new List<GameObject>();

    public int MaxHP => maxHP;
    public int CurrentHP => currentHP;

    private void Start()
    {
        currentHP = maxHP;

        for (int i = 0; i < maxHP; i++)
        {
            GameObject hpImage = Instantiate(PlayerHpPrefab, PlayerHpPos);
            hpImages.Add(hpImage);
        }
    }

    public void MonsterReachedGoal()
    {
        if (currentHP > 0)
        {
            currentHP --;
            UpdateHPUI();

        }
        else if (currentHP <= 0)
        {
            OnGameOver(); //게임오버 이벤트 함수 부르기 
        }
    }

    private void UpdateHPUI()
    {
        for (int i = 0; i < maxHP; i++)
        {
            if (i >= currentHP)
            {
                hpImages[i].SetActive(false);
            }
            else
            {
                hpImages[i].SetActive(true);
            }
        }
    }

    public event Action OnGameOver = delegate { };

}
