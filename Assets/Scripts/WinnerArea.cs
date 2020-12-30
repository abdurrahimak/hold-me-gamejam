using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerArea : MonoBehaviour
{
    // Start is called before the first frame update
    private bool character1Enter, character2Enter;
    private bool winLevel = false;
    private float _interval, _winTime = 2f;
    void Start()
    {
        _interval = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (winLevel)
        {
            return;
        }
        if(character1Enter && character2Enter)
        {
            _interval -= Time.deltaTime;
            if(_interval < 0f)
            {
                winLevel = true;
                GameController.Instance.LevelWin();
            }
        }
        else
        {
            _interval = _winTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ch1"))
        {
            character1Enter = true;
        }
        else if (other.tag.Equals("Ch2"))
        {
            character2Enter = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Ch1"))
        {
            character1Enter = false;
        }
        else if (other.tag.Equals("Ch2"))
        {
            character2Enter = false;
        }
    }
}
