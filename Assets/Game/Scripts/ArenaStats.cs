using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaStats : MonoBehaviour
{
    public List<GameObject> Enemy;
    public List<GameObject> Bullets;

    private PlayerMovement player;

    private void Start()
    {
        player = ServiceLocator.GetService<PlayerMovement>();
    }
    public GameObject NearestEnemy()
    {
        if (Enemy == null || Enemy.Count == 0) return null;
        
        GameObject nearEnemy = null;
        foreach (var enemy in Enemy)
        {
            if (enemy == null)
            {
                Enemy.Remove(enemy);
                continue;
            }

            if (nearEnemy == null)
            {
                nearEnemy = enemy;
                continue;
            }

            Vector2 playerPos = player.transform.position;
            float distance = Vector2.Distance(enemy.transform.position, playerPos);
            float nearDistance = Vector2.Distance(nearEnemy.transform.position, playerPos);
            
            if (distance < nearDistance) nearEnemy = enemy;
        }
        return nearEnemy;
    }
    public void AddEnemy(GameObject newEnemy)
    {
        foreach (var enemy in Enemy)
        {
            if (newEnemy == enemy)
            {
                return;
            }
        }
        Enemy.Add(newEnemy);
    }
}
