using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRanger : BaseTowerData
{
    public void RedSetData(string _name, float _att, float _attDelay, float _hp)
    {
        base.SetData(_name, _att, _attDelay, _hp);
    }

    public float ReflexDamageCalc(float _enemyAttValue)
    {
        float redHp = hp;
        return redHp / _enemyAttValue;
    }
}
