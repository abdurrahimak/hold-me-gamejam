using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWinView : MonoBehaviour
{
    public Text Text;
    void Start()
    {
        AudioSourceManager.Instance.PlayWinSound();
    }

    public void NextLevel()
    {
        AudioSourceManager.Instance.ClickButton();
        GameController.Instance.NextLevel();
    }

    public void Home()
    {
        AudioSourceManager.Instance.ClickButton();
        GameController.Instance.MainMenu();
    }

    internal void ChangeText(int level)
    {
        Text.text = $"Level {level}\n SUCCESS";
    }
}
