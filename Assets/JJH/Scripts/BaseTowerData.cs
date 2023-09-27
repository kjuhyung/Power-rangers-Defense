using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseTowerData : MonoBehaviour //이거를 붙혀도
{
    public GameObject Bullets;
    public string towerName { get; set; }
    public float att { get; set; }
    public float attDelay { get; set; }
    public float hp { get; set; }
    public float currentHp { get; set; }

    public virtual void Awake()
    {

    }

    public void SetData(string _name, float _att, float _attDelay, float _hp)
    {
        towerName = _name;
        att = _att;
        attDelay = _attDelay;
        hp = _hp;
        currentHp = _hp;
    }

    public void TowerDamaged(float monsterAttValue)
    {
        //todo
        //btd.currentHp -= monsterAttValue;
        //Debug.Log(currentHp + " tower");
        //if (hp < 0)
        //{
        //    Destroy(gameObject);
        //}
        
    }

    public bool TowerAttck()
    {
        Vector2 rayOrigin = transform.position;
        Vector2 rayDirection = Vector2.right; // 오른쪽 방향으로 레이 발사

        int layer = LayerMask.GetMask("Monster");
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, 30f, layer);

        if (hit.collider != null)
        {
            //anim.SetBool("isAttached", true);
            return true;
        }
        else
        {
            return false;
        }
        //Todo
    }

    public virtual IEnumerator SpawnBullet(BaseTowerData btd, GameObject bulletPoint)
    {
        while (true)
        {
            var go = Instantiate(Bullets);
            go.transform.position = bulletPoint.transform.position;
            
            Debug.Log("bts" + go.transform.position);
            yield return new WaitForSeconds(btd.attDelay);
        }
    }
}
