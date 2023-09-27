using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public GameObject gameOverUI;
    public GameObject winUI; // 게임 클리어 UI 오브젝트 추가
    private bool gameOver = false;
    private bool gameWon = false; // 게임 클리어 상태 추가
    private float gameOverTime = 0f;
    private float gameOverDelay = 60f; // 게임 클리어 대기 시간 설정

    void Update()
    {
        if (!gameOver && IsColliding(player, monster))
        {
            gameOver = true;
            GameOver(); // 게임 오버 함수 호출
        }

        if (!gameOver && player.GetComponent<PlayerHP>().CurrentHP <= 0)
        {
            gameOver = true;
            GameOver(); // 게임 오버 함수 호출
        }

        // 게임 오버 상태에서 60초가 지난 후 게임 클리어로 가정
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

    // 두 개의 게임 오브젝트 간의 충돌 여부를 확인하는 함수
    bool IsColliding(GameObject obj1, GameObject obj2)
    {
        // 각 게임 오브젝트에서 Collider 컴포넌트를 가져옵니다.
        Collider collider1 = obj1.GetComponent<Collider>();
        Collider collider2 = obj2.GetComponent<Collider>();

        // 두 게임 오브젝트 모두 Collider 컴포넌트를 가지고 있는 경우
        if (collider1 != null && collider2 != null)
        {
            // Collider의 경계 박스(bounding box)가 서로 겹치는지 확인하고
            // 겹치면 true를 반환하여 충돌이 발생한 것으로 판단합니다.
            return collider1.bounds.Intersects(collider2.bounds);
        }

        // 어느 하나라도 Collider 컴포넌트를 가지고 있지 않으면 충돌하지 않은 것으로 처리합니다.
        return false;
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
        // 패배 시 다이아몬드 보상을 주지 않음
        if (!gameWon)
        {
            // 패배 시 다이아몬드 보상을 주지 않음
        }
    }

    void GameWon()
    {
        winUI.SetActive(true); // 게임 클리어 UI 활성화
        RewardDiamonds(500); // 승리 시 500개의 다이아몬드 보상을 줌
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void RewardDiamonds(int amount)
    {
        // 다이아몬드 보상을 처리하는 코드
        DiaManager diaManager = FindObjectOfType<DiaManager>();
        if (diaManager != null)
        {
            diaManager.StageCleared();
        }
    }
}
