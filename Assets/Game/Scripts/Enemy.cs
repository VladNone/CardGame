using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1f;
    public int DamageToStun = 1;
    public float Hp = 1f;
    public float StunTime = 1f;
    public GameObject particle;

    private PlayerMovement player;
    private Rigidbody2D rb;
    private bool stun = false;
    private int damToStun;
    private bool isDead = false;
    private void Awake()
    {
        damToStun = DamageToStun;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ServiceLocator.GetService<ArenaStats>().AddEnemy(gameObject);
        player = ServiceLocator.GetService<PlayerMovement>();
    }
    private void Update()
    {
        if (!stun) Move();
    }
    public virtual void Move()
    {
        Vector3 direction = player.transform.position - transform.position;

        rb.velocity = direction.normalized * Speed;
    }
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        damToStun -= 1;
        if (damToStun <= 0)
        {
            stun = true;
            Invoke("StunExit", StunTime);
        }
        if (Hp <= 0 && !isDead)
        {
            isDead = true;
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    public void StunExit()
    {
        damToStun = DamageToStun;
        stun = false;
    }
}
