using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRanger : BaseTowerData
{
    Coroutine blackCor;
    public GameObject bp;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void BlackSetData(string _name, float _att, float _attDelay, float _hp)
    {
        base.SetData(_name, _att, _attDelay, _hp);
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
