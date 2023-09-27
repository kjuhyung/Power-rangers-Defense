using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRanger : BaseTowerData
{
    public float slowTime { get; set; }
    public float slowRange { get; set; }

    public void BlueSetData(string _name, float _att, float _attDelay, float _hp, float _slowTime)
    {
        base.SetData(_name, _att, _attDelay, _hp);
        slowTime = _slowTime;
    }

    void Start()
    {
        TowerManager.Instance.blueRanger = this;
    }

    public float CalcSlowRange(float towerAttValue)
    {


        return 0f;
    }

    public IEnumerator EnemyMovSpeedSlowRange(float enemyMoveSpeed)
    {
        yield return new WaitForSeconds(slowTime);

    }

    public override void Update()
    {
        TowerAttck(this);
    }
}
