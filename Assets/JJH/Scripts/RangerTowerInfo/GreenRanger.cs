using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRanger : BaseTowerData
{

    public void GreenSetData(string _name, float _att, float _attDelay, float _hp)
    {
        base.SetData(_name, _att, _attDelay, _hp);
    }

    void Start()
    {
        TowerManager.Instance.greenRanger = this;
    }

    public override void Update()
    {
        TowerAttck(this);
    }
}
