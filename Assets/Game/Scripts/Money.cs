using UnityEngine;

public class Money : MonoBehaviour
{
    public Vector3 Target;
    public float Speed = 10f;
    public float MultBounce = 2f;
    public int MoneyCount = 25;
    public float TimeSleep = 1f;

    private float timePast = 0f;

    private void Awake()
    {
        TimeSleep = Random.Range(0.5f, 1f);
        Target = Camera.main.ScreenToWorldPoint(ServiceLocator.GetService<PlayerMovement>().Money.textMoney.gameObject.transform.position);
        Target.z = 0f;

        MoveableSmoothDamp move = gameObject.AddComponent<MoveableSmoothDamp>();
        move.targetPosition = new Vector2
            (
                transform.position.x + Random.Range(-MultBounce, MultBounce), transform.position.y + Random.Range(-MultBounce, MultBounce)
            );
    }
    private void Update()
    {
        timePast += Time.deltaTime;
        if (timePast < TimeSleep) return;
        GetComponent<MoveableSmoothDamp>().targetPosition = Target;

        if (transform.position == Target)
        {
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
