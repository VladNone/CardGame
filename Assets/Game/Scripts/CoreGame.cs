using System.Collections;
using UnityEngine;

public class CoreGame : MonoBehaviour
{
    public bool IsGameplay { get; private set; } = true;
    public GameObject Enemy;

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

        Invoke("SwitchGameplay", 1f);
    }
    public void CheckEnemy()
    {
        if (arena.CountEnemy() <= 0 && IsGameplay)
        {
            hand.KillAllCards();
            IsGameplay = false;
            swap.Invoke("RerollSwapCards", 1f);
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
        for (int i = 0; i < enemyNextCount; i++)
        {
            Vector2 spawnPoint = new Vector2(Random.Range(-7f, 7f), Random.Range(-3f, 3f));
            Instantiate(Enemy, spawnPoint, transform.rotation);
        }
        enemyNextCount++;
    }
}
