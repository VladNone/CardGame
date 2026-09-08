using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1f;
    public Vector2 Direction;
    public float Hp = 3f;
    public bool TakeDamage = false;

    private Rigidbody2D rb;
    private float Timer = 1;
    private Deck deck;
    private CoreGame game;
    private AudioSource source;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        deck = ServiceLocator.GetService<Deck>();
        game = ServiceLocator.GetService<CoreGame>();
    }
    private void Update()
    {
        rb.velocity = Direction.normalized * Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Direction = Vector2.Reflect(Direction, collision.contacts[0].normal);
        source.pitch = Random.Range(0.8f, 1.2f);
        source.Play();
        Timer = 1;

        if (game.IsGameplay) deck.AddToHand();

        if (collision.collider.CompareTag("Enemy") && TakeDamage)
        {
            Hp -= 1f;
            Debug.Log(Hp);
            if (Hp <= 0f) gameObject.SetActive(false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Direction = Vector2.Reflect(Direction, collision.contacts[0].normal);
            Timer = 1;
        }
    }
}
