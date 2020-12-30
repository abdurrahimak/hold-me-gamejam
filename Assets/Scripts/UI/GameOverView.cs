using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSourceManager.Instance.PlayGameOverSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        AudioSourceManager.Instance.ClickButton();
        GameController.Instance.ReOpenLevel();
    }

    public void Home()
    {
        AudioSourceManager.Instance.ClickButton();
        GameController.Instance.MainMenu();
    }
}
