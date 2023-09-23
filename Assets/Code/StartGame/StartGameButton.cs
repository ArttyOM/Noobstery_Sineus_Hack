using Code.HUD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        ScreenSwitcher.ShowScreen(ScreenType.Game);
    }
}
