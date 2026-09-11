using UnityEngine;

public class DirectionSpawnCard : Card
{
    public GameObject Object;
    public bool IsReversed = false;
    public override void CardUse()
    {
        PlayerMovement player = ServiceLocator.GetService<PlayerMovement>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - player.transform.position;
        if (IsReversed) direction = -direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        Instantiate(Object, player.transform.position, rotation);

        Kill();
    }
}
