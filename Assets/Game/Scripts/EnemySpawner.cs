using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float LifeTimeMin = 1f;
    public float LifeTimeMax = 2f;
    public bool NextWave = false;
    public Color Color;

    private SpriteRenderer sprite;
    private Color color;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
    }
    private void Start()
    {
        ServiceLocator.GetService<ArenaStats>().AddEnemy(gameObject);
        if (!NextWave) Init();
        else
        {
            sprite.color = Color;
        }
    }
    public void Init()
    {
        sprite.color = color;
        Invoke("SpawnEnemy", Random.Range(LifeTimeMin, LifeTimeMax));
    }
    public void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
