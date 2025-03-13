using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameServiceLoader : MonoBehaviour
{
    public PlayerMovement Player;
    public LineRenderer Line;
    public Hand hand;
    public Deck deck;

    private void Awake()
    {
        ServiceLocator locator = new ServiceLocator();

        locator.RegisterService(Player);
        locator.RegisterService(Line);
        locator.RegisterService(hand);
        locator.RegisterService(deck);
    }
}
