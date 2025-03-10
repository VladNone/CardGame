using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCard : Card
{
    public GameObject Object;
    public override void CardUse()
    {
        PlayerMovement player = ServiceLocator.GetService<PlayerMovement>();

        Instantiate(Object, player.transform.position, player.transform.rotation);

        Destroy(gameObject);
    }
}
