using UnityEngine;

public class GreenRanger : BaseTowerData
{
    Coroutine greenCor;
    public GameObject bp;

    public void GreenSetData(string _name, float _att, float _attDelay, float _hp)
    {
        base.SetData(_name, _att, _attDelay, _hp);
    }

    public override string GetTowerName()
    {
        return TowerManager.Instance.greenRanger.towerName; // towerName 값을 반환
    }

    public override void Awake()
    {
        base.Awake();
    }

    public void Update()
    {
        if (TowerAttck() == true && greenCor == null)
        {
            anim.SetBool("isAttached", true);
            greenCor = StartCoroutine(SpawnBullet(TowerManager.Instance.greenRanger, bp));
        }
    }
}
