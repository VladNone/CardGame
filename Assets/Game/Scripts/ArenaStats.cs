using System.Collections.Generic;
using UnityEngine;

public class ArenaStats : MonoBehaviour
{
    public List<GameObject> Enemy;
    public List<GameObject> Bullets;
    public bool MouseLock = false;
    public GameObject Text;

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

            EnemySpawner spawner = Enemy[i].GetComponent<EnemySpawner>();
            if (spawner != null) continue;

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
    public int CountEnemy()
    {
        int enemyCount = 0;
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.Remove(Enemy[i]);
                i--;
                continue;
            }
            enemyCount++;
        }
        return enemyCount;
    }
    public bool OnlyStaySpawners()
    {
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.Remove(Enemy[i]);
                i--;
                continue;
            }

            EnemySpawner spawner = Enemy[i].GetComponent<EnemySpawner>();
            if (spawner == null) return false;
        }
        return true;
    }
    public void AddBullet(GameObject newBullet)
    {
        Bullets.Add(newBullet);
    }
    public void KillAllBullets()
    {
        for (int i = 0; i < Bullets.Count; i++)
        {
            if (Bullets[i] != null) Destroy(Bullets[i]);
        }
        Bullets.Clear();
    }
}
