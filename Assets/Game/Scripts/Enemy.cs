using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1f;
    public int DamageToStun = 1;
    public float Hp = 1f;
    public float StunTime = 1f;
    public GameObject particle;
    public GameObject Money;

    protected PlayerMovement player;
    protected Rigidbody2D rb;
    private bool stun = false;
    private int damToStun;
    private bool isDead = false;
    private AudioSource source;
    private IDestroyable spikes;
    private void Awake()
    {
        damToStun = DamageToStun;
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        ServiceLocator.GetService<ArenaStats>().AddEnemy(gameObject);
        player = ServiceLocator.GetService<PlayerMovement>();
        spikes = GetComponent<IDestroyable>();
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
        source.pitch = Random.Range(0.8f, 1.2f);
        source.Play();
        damToStun -= 1;
        if (damToStun <= 0)
        {
            stun = true;
            Invoke("StunExit", StunTime);
        }
        if (spikes != null) spikes.TakeDamage(damage);
        if (Hp <= 0 && !isDead)
        {
            isDead = true;
            Instantiate(particle, transform.position, transform.rotation);
            if (Money != null)
            {
                for (int i = 0; i < Random.Range(3, 5); i++)
                {
                    Money money = Instantiate(Money, transform.position, transform.rotation).GetComponent<Money>();
                    money.MoneyCount = Random.Range(10, 55);
                }
            }
            Destroy(gameObject);
        }
    }
    public void StunExit()
    {
        damToStun = DamageToStun;
        stun = false;
    }
    private void OnDestroy()
    {
        if (ServiceLocator.GetService<CoreGame>() != null) ServiceLocator.GetService<CoreGame>().Invoke("CheckEnemy", 0.1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.stun && enemy.GetComponent<Rigidbody2D>().velocity.magnitude > 1)
            {
                TakeDamage(1f);
            }
        }
    }
}
