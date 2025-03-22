using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float LifeTimeMin = 1f;
    public float LifeTimeMax = 2f;
    private void Start()
    {
        ServiceLocator.GetService<ArenaStats>().AddEnemy(gameObject);
        Invoke("SpawnEnemy", Random.Range(LifeTimeMin, LifeTimeMax));
    }
    public void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
