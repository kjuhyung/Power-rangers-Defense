using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseTowerData : MonoBehaviour //이거를 붙혀도
{
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

    public void TowerGetDmg(float monsterAttValue)
    {
        //todo
    }

    public void TowerGiveDmg(int _towerAttVlaue)
    {
        //todo
    }
}
