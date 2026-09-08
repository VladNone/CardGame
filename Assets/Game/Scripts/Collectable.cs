using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Tutorial Check;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) Collect();
    }
    public virtual void Collect()
    {
        Check.CheckPoints();
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (Check != null) Check.CheckPoints();
    }
}
