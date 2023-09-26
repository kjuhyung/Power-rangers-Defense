using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public GameObject gameOverUI;
    public GameObject winUI; // 게임 클리어 UI 오브젝트 추가
    private bool gameOver = false;
    private bool gameWon = false; // 게임 클리어 상태 추가
    private float gameOverTime = 0f;
    private float gameOverDelay = 5f; // 게임 오버 후 대기 시간 설정

    void Update()
    {
        if (!gameOver && !gameWon && IsColliding(player, monster))
        {
            gameOver = true;
            gameOverTime = Time.time; // 충돌 시간 기록
            GameOver();
        }

        // 게임 오버 상태에서 5초가 지난 후 게임 클리어로 가정
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
        winUI.SetActive(true); // 게임 클리어 UI 활성화
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

