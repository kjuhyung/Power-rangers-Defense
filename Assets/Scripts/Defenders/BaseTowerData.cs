using System.Collections;
using UnityEngine;

public abstract class BaseTowerData : MonoBehaviour //이거를 붙혀도
{
    public GameObject Bullets;

    public Animator anim;
    public string towerName { get; set; }
    public float att { get; set; }
    public float attDelay { get; set; }
    public float hp { get; set; }
    public float currentHp { get; set; }

    public virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void SetData(string _name, float _att, float _attDelay, float _hp)
    {
        towerName = _name;
        att = _att;
        attDelay = _attDelay;
        hp = _hp;
        currentHp = _hp;
    }

    public virtual string GetTowerName()
    {
        return towerName;
    }

    public void TowerDamaged(string towerName,float monsterAttValue)
    {
        //todo
        currentHp -= monsterAttValue;
        if (currentHp <= 0)
        {
            TowerManager.Instance.DestroyRangerTower(towerName);
        }

    }

    public bool TowerAttck()
    {
        Vector2 rayOrigin = transform.position;
        Vector2 rayDirection = Vector2.right; // 오른쪽 방향으로 레이 발사

        int layer = LayerMask.GetMask("Monster");
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity , layer);
        
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
        //Todo
    }

    public virtual IEnumerator SpawnBullet(BaseTowerData btd, GameObject bulletPoint)
    {
        while (true)
        {
            var go = Instantiate(Bullets);
            go.transform.position = bulletPoint.transform.position;
            
            yield return new WaitForSeconds(btd.attDelay);
        }
    }
}