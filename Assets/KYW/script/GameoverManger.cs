using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject winUI;
    public bool gameWon = false;

    // �÷��̾� HP ���� ������ UI
    public GameObject PlayerHpPrefab;
    public Transform PlayerHpPos;
    private List<GameObject> hpImages = new List<GameObject>();
    private int maxHP = 5; // �÷��̾� ���
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

        // �й� �� ���̾Ƹ�� ������ ���� ����
        if (!gameWon)
        {
            // �й� �� ���̾Ƹ�� ������ ���� ����
        }
    }

    private void GameWon()
    {
        winUI.SetActive(true);
        RewardDiamonds(500); // �¸� �� 500���� ���̾Ƹ�� ������ ��
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void RewardDiamonds(int amount)
    {
        // ���̾Ƹ�� ������ ó���ϴ� �ڵ�
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
