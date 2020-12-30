using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.text = $"Level : {GameController.Instance.CurrentLevel}";
    }

    public void Play()
    {
        AudioSourceManager.Instance.ClickButton();
        GameController.Instance.OpenLevel();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
