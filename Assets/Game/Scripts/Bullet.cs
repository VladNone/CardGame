using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public float Damage = 1f;
    public float Force = 50f;

    private void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.position += transform.right * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * Force);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Wall")) Destroy(gameObject);
    }
}
