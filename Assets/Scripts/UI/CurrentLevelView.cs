using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevelView : MonoBehaviour
{
    public Text Text;

    void Start()
    {
        Text.text = $"Level {GameController.Instance.CurrentLevel}";
    }

    public void Retry()
    {
        ClickSound();
        GameController.Instance.ReOpenLevel();
    }

    public void Home()
    {
        ClickSound();
        GameController.Instance.MainMenu();
    }

    public void ClickSound()
    {
        AudioSourceManager.Instance.ClickButton();
    }
}
