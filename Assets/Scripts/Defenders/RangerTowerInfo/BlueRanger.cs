using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRanger : BaseTowerData
{
    Coroutine blueCor;
    public GameObject bp;
    public float slowTime { get; set; }
    public float slowRange { get; set; }

    public void BlueSetData(string _name, float _att, float _attDelay, float _hp, float _slowTime)
    {
        base.SetData(_name, _att, _attDelay, _hp);
        slowTime = _slowTime;
    }

    public override string GetTowerName()
    {
        return TowerManager.Instance.blueRanger.towerName; // towerName 값을 반환
    }

    public override void Awake()
    {
        base.Awake();
    }

    public void Update()
    {
        if (TowerAttck() == true && blueCor == null)
        {
            blueCor = StartCoroutine(SpawnBullet(TowerManager.Instance.blueRanger, bp));
        }
    }

    public float CalcSlowRange(float towerAttValue)
    {


        return 0f;
    }

    public IEnumerator EnemyMovSpeedSlowRange(float enemyMoveSpeed)
    {
        yield return new WaitForSeconds(slowTime);


    }
}
