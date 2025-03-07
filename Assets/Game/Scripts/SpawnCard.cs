using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCard : Card
{
    public GameObject Spawn;
    public override void CardUse()
    {
        PlayerMovement player = ServiceLocator.GetService<PlayerMovement>();

        Instantiate(Spawn, player.transform.position, player.transform.rotation);

        Destroy(gameObject);
    }
}
