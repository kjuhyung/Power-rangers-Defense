using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRanger : BaseTowerData
{
    Coroutine greenCor;
    public GameObject bp;
    Animator anim;
    public void GreenSetData(string _name, float _att, float _attDelay, float _hp)
    {
        base.SetData(_name, _att, _attDelay, _hp);
    }


    public void Update()
    {
        if (TowerAttck() == true && greenCor == null)
        {
            greenCor = StartCoroutine(SpawnBullet(TowerManager.Instance.greenRanger, bp));
        }
    }
}
