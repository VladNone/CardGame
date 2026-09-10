using UnityEngine;

public class Money : MonoBehaviour
{
    public Transform Target;
    public float Speed = 10f;
    public float MultBounce = 2f;
    public int MoneyCount = 25;
    public float TimeSleep = 1f;

    private float timePast = 0f;

    private void Update()
    {
        timePast += Time.deltaTime;
        if (timePast < TimeSleep) return;


        transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        if (transform.position == Target.position)
        {
            Target.position = new Vector2
                (
                    transform.position.x + Random.Range(-MultBounce, MultBounce), transform.position.y + Random.Range(-MultBounce, MultBounce)
                );
            ScaleKill kill = gameObject.AddComponent<ScaleKill>();
            kill.Speed = 5f;
            kill.IsScaleKill = true;
        }
    }
    private void OnDestroy()
    {
        MoneyCounter money = ServiceLocator.GetService<PlayerMovement>().Money;

        if (money != null) money.Moneys = money.Moneys + MoneyCount;
    }
}
