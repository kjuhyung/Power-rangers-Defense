using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public GameObject gameOverUI;
    public GameObject winUI; // ���� Ŭ���� UI ������Ʈ �߰�
    private bool gameOver = false;
    private bool gameWon = false; // ���� Ŭ���� ���� �߰�
    private float gameOverTime = 0f;
    private float gameOverDelay = 5f; // ���� ���� �� ��� �ð� ����

    void Update()
    {
        if (!gameOver && !gameWon && IsColliding(player, monster))
        {
            gameOver = true;
            gameOverTime = Time.time; // �浹 �ð� ���
            GameOver();
        }

        // ���� ���� ���¿��� 5�ʰ� ���� �� ���� Ŭ����� ����
        if (gameOver && !gameWon && Time.time - gameOverTime >= gameOverDelay)
        {
            gameWon = true;
            GameWon();
        }

        if (gameWon && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    bool IsColliding(GameObject obj1, GameObject obj2)
    {
        Collider collider1 = obj1.GetComponent<Collider>();
        Collider collider2 = obj2.GetComponent<Collider>();

        if (collider1 != null && collider2 != null)
        {
            return collider1.bounds.Intersects(collider2.bounds);
        }

        return false;
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    void GameWon()
    {
        winUI.SetActive(true); // ���� Ŭ���� UI Ȱ��ȭ
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
