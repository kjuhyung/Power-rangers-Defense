using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject winUI;
    public bool gameWon = false;

    // 플레이어 HP 관련 변수와 UI
    public GameObject PlayerHpPrefab;
    public Transform PlayerHpPos;
    private List<GameObject> hpImages = new List<GameObject>();
    private int maxHP = 5; // 플레이어 목숨
    private int currentHP;

    private void Start()
    {
        currentHP = maxHP;

        for (int i = 0; i < maxHP; i++)
        {
            GameObject hpImage = Instantiate(PlayerHpPrefab, PlayerHpPos);
            hpImages.Add(hpImage);
        }
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);

        // 패배 시 다이아몬드 보상을 주지 않음
        if (!gameWon)
        {
            // 패배 시 다이아몬드 보상을 주지 않음
        }
    }

    private void GameWon()
    {
        winUI.SetActive(true);
        RewardDiamonds(500); // 승리 시 500개의 다이아몬드 보상을 줌
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void RewardDiamonds(int amount)
    {
        // 다이아몬드 보상을 처리하는 코드
        DiaManager diaManager = FindObjectOfType<DiaManager>();
        if (diaManager != null)
        {
            diaManager.StageCleared();
        }
    }

    public void MonsterReachedGoal()
    {
        if (currentHP > 0)
        {
            currentHP--;
            UpdateHPUI();
        }
        else if (currentHP == 0)
        {
            GameOver();
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
}

