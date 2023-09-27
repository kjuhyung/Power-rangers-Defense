using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterPrefabs;

    private List<GameObject>[] monsterPools;

    private Transform[] spawnPoint;
    [SerializeField] private Transform MonsterPool;

    private float spawnTimer;

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

        if (spawnTimer > 0.5f )
        {
            spawnTimer = 0;
            SpawnMonster();
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
