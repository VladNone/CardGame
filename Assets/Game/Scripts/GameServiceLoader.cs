using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameServiceLoader : MonoBehaviour
{
    public PlayerMovement Player;

    private void Awake()
    {
        ServiceLocator locator = new ServiceLocator();

        locator.RegisterService(Player);
    }
}
