using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1f;
    private PlayerMovement player;
    private void Start()
    {
        ServiceLocator.GetService<ArenaStats>().AddEnemy(gameObject);
        player = ServiceLocator.GetService<PlayerMovement>();
    }
    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        transform.position += direction.normalized * Speed * Time.deltaTime;
    }
}
