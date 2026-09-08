using UnityEngine;

public class CoreGame : MonoBehaviour
{
    public bool IsGameplay { get; private set; } = true;
    public GameObject Spawner;
    public int MaxEnemyBeforeWaves = 3;

    private PlayerMovement player;
    private SwapCard swap;
    private ArenaStats arena;
    private Hand hand;
    private Deck deck;
    private int enemyNextCount = 1;
    private void Start()
    {
        swap = ServiceLocator.GetService<SwapCard>();
        arena = ServiceLocator.GetService<ArenaStats>();
        hand = ServiceLocator.GetService<Hand>();
        deck = ServiceLocator.GetService<Deck>();

        //Invoke("SwitchGameplay", 1f);
    }
    public void CheckEnemy()
    {
        if (arena.CountEnemy() <= 0 && IsGameplay)
        {
            hand.KillAllCards();
            arena.KillAllBullets();
            IsGameplay = false;
            swap.Invoke("RerollSwapCards", 1f);  // Поменять на метод который будет спавнить коробку с рандом ивентами
        }

        if (arena.OnlyStaySpawners() && IsGameplay)
        {
            foreach (GameObject spawner in arena.Enemy)
            {
                spawner.GetComponent<EnemySpawner>().Init();
            }
        }
    }
    public void SwitchGameplay()
    {
        IsGameplay = true;
        deck.AddToHand();
        deck.AddToHand();
        deck.AddToHand();
        deck.AddToHand();

        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        int currentEnemyCount = 0;
        for (int i = 0; i < enemyNextCount; i++)
        {
            Vector2 spawnPoint = new Vector2(Random.Range(-7f, 7f), Random.Range(-3f, 3f));
            currentEnemyCount++;
            GameObject spawner = Instantiate(Spawner, spawnPoint, transform.rotation);
            if (enemyNextCount > MaxEnemyBeforeWaves && currentEnemyCount > enemyNextCount / 2) spawner.GetComponent<EnemySpawner>().NextWave = true;
        }
        if (Random.Range(0f, 1f) > 0.25f) enemyNextCount++;
    }
}
