using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DirectionSpawnCard : Card
{
    public GameObject Object;
    public override void CardUse()
    {
        PlayerMovement player = ServiceLocator.GetService<PlayerMovement>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - player.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        Instantiate(Object, player.transform.position, rotation);

        Kill();
    }
}
