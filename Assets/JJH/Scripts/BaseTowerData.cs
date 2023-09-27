using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseTowerData : MonoBehaviour //이거를 붙혀도
{
    Ray2D ray;
    RaycastHit hit;
    Transform tr;

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

    void Awake()
    {
        tr = GetComponent<Transform>();
    }

    public void TowerDamaged(float monsterAttValue)
    {
        //todo
    }

    public void TowerAttck()//int _towerAttVlaue
    {
        //ray = new Ray2D(tr.position, Vector2.right);
        //if(Physics.Raycast(ray, out hit, 100f))
        //{
        //    if (hit.transform.CompareTag("Monster"))
        //    {
        //        Instantiate(Bullets);
        //        Debug.DrawRay
        //        Debug.Log("asd");
        //    }
        //}
        //Todo
    }

    public virtual void Update()
    {
        TowerAttck();
    }
}
