using System.Collections;
using System.Collections.Generic;
using Code.HUD;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private Button StartButton;

    private void Awake()
    {
        StartButton = gameObject.GetComponent<Button>();
        StartButton.onClick.AddListener(LaunchGame);
    }

    private void LaunchGame()
    {
        Time.timeScale = 1;
        ScreenSwitcher.ShowScreen(ScreenType.Game);
    }
}
