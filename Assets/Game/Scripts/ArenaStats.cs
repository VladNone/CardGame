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
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.Remove(Enemy[i]);
                i--;
                continue;
            }

            if (nearEnemy == null)
            {
                nearEnemy = Enemy[i];
                continue;
            }

            Vector2 playerPos = player.transform.position;
            float distance = Vector2.Distance(Enemy[i].transform.position, playerPos);
            float nearDistance = Vector2.Distance(nearEnemy.transform.position, playerPos);
            
            if (distance < nearDistance) nearEnemy = Enemy[i];
        }
        return nearEnemy;
    }
    public void AddEnemy(GameObject newEnemy)
    {
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.Remove(Enemy[i]);
                continue;
            }

            if (newEnemy == Enemy[i])
            {
                return;
            }
        }
        Enemy.Add(newEnemy);
    }
}
