using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCard : Card
{
    public override void CardUse()
    {
        PlayerMovement player = ServiceLocator.GetService<PlayerMovement>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - player.transform.position;

        player.Direction = direction;

        Destroy(gameObject);
    }
}
