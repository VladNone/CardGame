using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRotation : MonoBehaviour
{
    private PlayerMovement player;
    private void Start()
    {
        player = ServiceLocator.GetService<PlayerMovement>();
    }
    private void Update()
    {
        Vector2 direction = -player.Direction.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
