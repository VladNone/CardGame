using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 1f;

    private void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.position += transform.right * Speed * Time.deltaTime;
    }
}
