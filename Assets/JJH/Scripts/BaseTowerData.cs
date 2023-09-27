using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseTowerData : MonoBehaviour //이거를 붙혀도
{
    public GameObject Bullets;
    public string towerName { get; set; }
    public float att { get; set; }
    public float attDelay { get; set; }
    public float hp { get; set; }


    public void SetData(string _name, float _att, float _attDelay, float _hp)
    {
        towerName = _name;
        att = _att;
        attDelay = _attDelay;
        hp = _hp;
    }

    public void TowerDamaged(float monsterAttValue)
    {
        //todo
    }

    public void TowerAttck(BaseTowerData btd)//int _towerAttVlaue
    {
        Vector2 rayOrigin = transform.position;
        Vector2 rayDirection = Vector2.right; // 오른쪽 방향으로 레이 발사

        int layer = LayerMask.GetMask("Monster");
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, layer);

        if (hit.collider != null)
        {
            float attDelay = btd.attDelay;
            InvokeRepeating(nameof(SpawnBullet), 0f, attDelay);
        }
        //Todo
    }

    public void SpawnBullet()
    {
        Instantiate(Bullets);
        Debug.Log(attDelay);
    }

    public virtual void Update()
    {

    }
}
