using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public BaseTowerData rangerTower;
    

    

    public float bulletSpeed = 10f;
    Rigidbody2D rb;

    void Awake()
    {

    }

    void Start()
    {
        rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet.transform.position.x > 15)
        {
            Destroy(bullet);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            print(monster.curHealth);
            monster.MosterTakeDamage(rangerTower.att);
        }
    }
}
