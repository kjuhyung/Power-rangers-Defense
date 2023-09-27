using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterPrefabs;

    private List<GameObject>[] monsterPools;

    private Transform[] spawnPoint;
    [SerializeField] private Transform MonsterPool;

    private float spawnTimer;
    private int spawnLevel;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();

        monsterPools = new List<GameObject>[monsterPrefabs.Length];

        for (int i = 0; i < monsterPools.Length; i++)
        {
            monsterPools[i] = new List<GameObject>();
        }
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime;
        spawnLevel = Mathf.FloorToInt(GameManager.instance.gameTime / 10f);
        // if(SceneManager.GetActiveScene().buildIndex == 2)
        // {

        // }
        switch (spawnLevel)
        {
            case 0:
                if (spawnTimer > 2f)
                {
                    spawnTimer = 0;
                    SpawnMonster();
                }
                break;
            case 1:
                if (spawnTimer > 1.5f)
                {
                    spawnTimer = 0;
                    SpawnMonster();
                }
                break;
            case 2:
                if (spawnTimer > 1f)
                {
                    spawnTimer = 0;
                    SpawnMonster();
                }
                break;            
        }
    }
    private void SpawnMonster()
    {
       GameObject monster = GetMonster(Random.Range(0, 3));
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length - 1)].position;
    }

    private GameObject GetMonster(int index)
    {
        GameObject selectMonster = null;

        foreach (GameObject monster in monsterPools[index])
        {
            if (!monster.activeSelf)
            {
                selectMonster = monster;
                selectMonster.SetActive(true);
                break;
            }
        } 

        if (!selectMonster)
        {
           selectMonster = Instantiate(monsterPrefabs[index], MonsterPool.transform);
            monsterPools[index].Add(selectMonster);
        }

        return selectMonster;
    }
}
