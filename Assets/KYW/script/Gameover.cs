using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager ����� ���� �߰�

public class GameOverManager : MonoBehaviour
{
    public GameObject player; // �÷��̾� ���� ������Ʈ
    public GameObject monster; // ���� ���� ������Ʈ

    private bool gameOver = false; // ���� ���� ���¸� ��Ÿ���� ����

    void Update()
    {
        // ���� ���� ���°� �ƴϰ� �÷��̾�� ���Ͱ� �浹�ϸ� ���� ����
        if (!gameOver && IsColliding(player, monster))
        {
            gameOver = true;
            GameOver(); // ���� ���� �Լ� ȣ��
        }
    }

    bool IsColliding(GameObject obj1, GameObject obj2)
    {
        // �� ���� ������Ʈ�� �浹�� �����ϴ� �ڵ�
        // ���⿡ ������ �浹 ���� ����� ����ؾ� �մϴ�.
        // ���� ���, Collider ������Ʈ�� ����Ͽ� �浹�� ������ �� �ֽ��ϴ�.
        // �� �ڵ�� �浹 ���� ����� ���� �ٸ� �� �ֽ��ϴ�.
        // �Ʒ��� ���÷� BoxCollider�� ����ϴ� ����Դϴ�.
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
        // ���� ���� ���¿��� �� �۾��� ���⿡ �߰��մϴ�.
        // ���� ���, ���� ���� UI�� Ȱ��ȭ�ϰų� ���� ���� ������ �߰��� �� �ֽ��ϴ�.

        // ������ �����ϰų� �ٽ� �����ϰų� �ٸ� �۾��� �����Ϸ��� SceneManager�� ����� �� �ֽ��ϴ�.
        // �Ʒ��� ���� ���� �ٽ� �ε��ϴ� �����Դϴ�.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
