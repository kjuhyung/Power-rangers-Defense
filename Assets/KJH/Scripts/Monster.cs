using UnityEngine;

public class Monster : MonoBehaviour
{
    private enum MonsterType { Pink = 1, Owlet, Dude }
    [SerializeField] private MonsterType monsterType;

    private Rigidbody2D _rigid;
    private Animator _anim;

    public float curHealth { get; set; }
    public float maxHealth { get; private set; }
    public float attackDamage { get; private set; }
    private float attackDelay;
    public float moveSpeed { get; set; }
    private int goldPerDeath;

    private bool IsDeath;
    private bool IsAttacking;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        IsDeath = false;
        IsAttacking = false;
        curHealth = maxHealth;

        switch (monsterType)
        {
            case MonsterType.Pink:
                maxHealth = 200f;
                attackDamage = 5;
                attackDelay = 1f;
                moveSpeed = 20f;
                goldPerDeath = 5;
                break;
            case MonsterType.Owlet:
                maxHealth = 300f;
                attackDamage = 15;
                attackDelay = 2f;
                moveSpeed = 10f;
                goldPerDeath = 15;
                break;
            case MonsterType.Dude:
                maxHealth = 100f;
                attackDamage = 10;
                attackDelay = 0.5f;
                moveSpeed = 30f;
                goldPerDeath = 10;
                break;
        }
    }

    private void FixedUpdate()
    {
        MonsterMove();     
    }

    private void MonsterMove()
    {
        if (IsDeath || IsAttacking)
        {
            _rigid.velocity = Vector2.zero;
            _anim.SetBool("IsRun", false);
        }
        else
        {
            _rigid.velocity = Vector2.left * moveSpeed * Time.fixedDeltaTime;
            _anim.SetBool("IsRun", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Defender")
        {
            IsAttacking = true;
            Debug.Log("타워 충돌");
            InvokeRepeating(nameof(MonsterGiveAttack), 0, attackDelay);
        }
        else if (other.tag == "Earth")
        {
            // TODO
            // gameObject.SetActive(false);
            // spawnmanager 에게 반환
            // 플레이어 피 감소
        }
        else return;            
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Defender")
        {
            IsAttacking = false;
            CancelInvoke(nameof(MonsterGiveAttack));
        }
        else return;
    }

    private void MonsterGiveAttack()
    {
        // TODO
        // 데미지 주기
        _anim.SetTrigger("Attack");        
    }

    public void MosterTakeDamage(float _damage)
    {
        curHealth -= _damage;
        _anim.SetTrigger("Hit");

        if (curHealth <= 0)
        {
            // TODO
            // PlayerGold.currentGold += goldPerDeath;
            IsDeath = true;
            _anim.SetTrigger("Death");
        }
    }

    private void MonsterDestroy()
    {
        gameObject.SetActive(false);
    }
}
