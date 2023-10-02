using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRanger : BaseTowerData
{
    Coroutine blackCor;
    public GameObject bp;

    public void BlackSetData(string _name, float _att, float _attDelay, float _hp)
    {
        base.SetData(_name, _att, _attDelay, _hp);
    }

    public override string GetTowerName()
    {
        return towerName; // towerName 값을 반환
    }

    public override void Awake()
    {
        base.Awake();
    }

    public void Update()
    {
        if (TowerAttck() == true && blackCor == null)
        {
            anim.SetBool("isAttached", true);
            blackCor = StartCoroutine(SpawnBullet(TowerManager.Instance.blackRanger, bp));
        }
    }
}
