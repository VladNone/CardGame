using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1f;
    public Vector2 Direction;

    private Rigidbody2D rb;
    private float Timer = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = Direction.normalized * Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Direction = Vector2.Reflect(Direction, collision.contacts[0].normal);
        Timer = 1;
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
