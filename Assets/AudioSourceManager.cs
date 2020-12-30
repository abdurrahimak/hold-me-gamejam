using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _buttonSource;
    [SerializeField] private AudioSource _winLoseSource;

    [Header("Clips")]
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private AudioClip _buttonClip;
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private AudioClip _gameOverClip;

    private static AudioSourceManager _instance;
    public static AudioSourceManager Instance => _instance;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _musicSource.clip = _musicClip;
        _musicSource.playOnAwake = true;
        _musicSource.loop = true;
        _musicSource.Play();

        _buttonSource.playOnAwake = false;
        _buttonSource.loop = false;
        _buttonSource.clip = _buttonClip;

        _winLoseSource.playOnAwake = false;
        _winLoseSource.loop = false;
        _winLoseSource.clip = _buttonClip;
    }

    public void PlayWinSound()
    {
        _winLoseSource.clip = _winClip;
        _winLoseSource.Play();
    }

    public void PlayGameOverSound()
    {
        _winLoseSource.clip = _gameOverClip;
        _winLoseSource.Play();
    }

    public void ClickButton()
    {
        _buttonSource.Play();
    }
}
