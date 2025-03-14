using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullet : Bullet
{
    private PlayerMovement player;
    private void Start()
    {
        player = ServiceLocator.GetService<PlayerMovement>();
        GameObject enemy = ServiceLocator.GetService<ArenaStats>().NearestEnemy();

        Vector2 direction = new();

        if (enemy != null) direction = enemy.transform.position - player.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        transform.rotation = rotation;
    }
}
