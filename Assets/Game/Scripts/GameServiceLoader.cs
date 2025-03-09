using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameServiceLoader : MonoBehaviour
{
    public PlayerMovement Player;
    public LineRenderer Line;

    private void Awake()
    {
        ServiceLocator locator = new ServiceLocator();

        locator.RegisterService(Player);
        locator.RegisterService(Line);
    }
}
