using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class FastEnemy : Enemy
{
    public float RotationSpeed = 1f;
    public override void Move()
    {
        Vector2 direction = player.transform.position - transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float currentAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, RotationSpeed * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(0, 0, currentAngle);

        rb.velocity = transform.right * Speed;
    }
}
