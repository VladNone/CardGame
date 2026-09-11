using UnityEngine;

public class Sword : MonoBehaviour
{
    public float RotationSpeed = 5f;
    public float KillSpeed = 5f;
    public float Damage = 2f;
    public float Force = 100f;

    private bool right = false;
    private float pastAngle = 0f;

    private void Start()
    {
        transform.parent = ServiceLocator.GetService<PlayerMovement>().transform;

        if (Random.Range(0, 2) == 1)
        {
            right = true;
        }
        
    }
    private void Update()
    {
        float rotate = RotationSpeed * Time.deltaTime;


        if (right)
        {
            transform.Rotate(0, 0, rotate);
        }
        else
        {
            transform.Rotate(0, 0, -rotate);
        }

        pastAngle += rotate;

        if (pastAngle >= 360)
        {
            ScaleKill kill = gameObject.AddComponent<ScaleKill>();
            kill.Speed = KillSpeed;
            kill.IsScaleKill = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * Force);
        }
    }
}
