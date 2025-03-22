using UnityEngine;

[DefaultExecutionOrder(-9999)]
public class GameServiceLoader : MonoBehaviour
{
    public PlayerMovement Player;
    public LineRenderer Line;
    public Hand hand;
    public Deck deck;
    public ArenaStats arena;
    public SwapCard swapCards;
    public CoreGame game;

    private void Awake()
    {
        ServiceLocator locator = new ServiceLocator();

        locator.RegisterService(Player);
        locator.RegisterService(Line);
        locator.RegisterService(hand);
        locator.RegisterService(deck);
        locator.RegisterService(arena);
        locator.RegisterService(swapCards);
        locator.RegisterService(game);  
    }
}
