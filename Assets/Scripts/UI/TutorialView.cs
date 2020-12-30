using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialView : MonoBehaviour
{
    public void CloseTutorial()
    {
        AudioSourceManager.Instance.ClickButton();
        GameController.Instance.TutorialActive = false;
        Destroy(gameObject);
    }
}
