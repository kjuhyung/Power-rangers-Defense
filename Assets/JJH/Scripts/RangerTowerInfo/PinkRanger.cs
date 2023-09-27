using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkRanger : BaseTowerData
{
    Coroutine pinkCor;
    public GameObject bp;
    Animator anim;
    public float heal { get; set; }

    public void PinkSetData(string _name, float _att, float _attDelay, float _hp, float _heal)
    {
        base.SetData(_name, _att, _attDelay, _hp);
        
        heal = _heal;
    }


    public void Update()
    {
        if (TowerAttck() == true && pinkCor == null)
        {
            pinkCor  = StartCoroutine(SpawnBullet(TowerManager.Instance.pinkRanger, bp));
        }
    }
}
