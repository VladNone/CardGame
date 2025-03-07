using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1f;
    public Vector2 Direction;

    private Rigidbody2D rb;

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
        if (collision.collider.CompareTag("Wall"))
        {
            Direction = Vector2.Reflect(Direction, collision.contacts[0].normal);
        }
    }
}
