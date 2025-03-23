using UnityEngine;

public class MoveableSmoothDamp : MonoBehaviour
{
    public Vector2 targetPosition;
    private Vector2 velocity;
    public float smoothTime = 0.15F;
    public float maxVelocity = 30f;
    private Vector2 currentVelocity;

    private void Update()
    {
        MoveXY();
    }

    protected void MoveXY()
    {
        if (Vector2.Distance(transform.position, targetPosition) > 0.01f || velocity.magnitude > 0.01f)
        {
            Vector2 newPosition = Vector2.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, maxVelocity, Time.unscaledDeltaTime);
            velocity = (newPosition - (Vector2)transform.position) / Time.unscaledDeltaTime;

            if (velocity.sqrMagnitude > maxVelocity * maxVelocity)
            {
                velocity = velocity.normalized * maxVelocity;
            }

            transform.position = newPosition + velocity * Time.unscaledDeltaTime;
            if (Vector2.Distance((Vector2)transform.position, targetPosition) < 0.01f && velocity.magnitude < 0.01f)
            {
                transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
                velocity = Vector2.zero;
            }
        }
    }
}