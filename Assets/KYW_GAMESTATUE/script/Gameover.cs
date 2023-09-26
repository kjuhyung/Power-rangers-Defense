using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager 사용을 위해 추가

public class GameOverManager : MonoBehaviour
{
    public GameObject player; // 플레이어 게임 오브젝트
    public GameObject monster; // 몬스터 게임 오브젝트

    private bool gameOver = false; // 게임 오버 상태를 나타내는 변수

    void Update()
    {
        // 게임 오버 상태가 아니고 플레이어와 몬스터가 충돌하면 게임 종료
        if (!gameOver && IsColliding(player, monster))
        {
            gameOver = true;
            GameOver(); // 게임 오버 함수 호출
        }
    }

    bool IsColliding(GameObject obj1, GameObject obj2)
    {
        // 두 게임 오브젝트의 충돌을 감지하는 코드
        // 여기에 적절한 충돌 감지 방법을 사용해야 합니다.
        // 예를 들어, Collider 컴포넌트를 사용하여 충돌을 감지할 수 있습니다.
        // 이 코드는 충돌 감지 방법에 따라 다를 수 있습니다.
        // 아래는 예시로 BoxCollider를 사용하는 방법입니다.
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
        // 게임 오버 상태에서 할 작업을 여기에 추가합니다.
        // 예를 들어, 게임 오버 UI를 활성화하거나 게임 종료 로직을 추가할 수 있습니다.

        // 게임을 종료하거나 다시 시작하거나 다른 작업을 수행하려면 SceneManager를 사용할 수 있습니다.
        // 아래는 현재 씬을 다시 로드하는 예제입니다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

