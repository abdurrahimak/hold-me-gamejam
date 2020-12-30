using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int CurrentLevel;
    public Vector3 CameraStartPos;

    private LevelWinView _levelWinView;
    private GameData _gameData;
    private ResourceController _resourceController;
    private PlayerController _playerController;
    private GameObject _levelGameObject;

    private static GameController _instance;
    public static GameController Instance => _instance;

    public bool TutorialActive { get; set; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        _gameData = new GameData();
        _resourceController = new ResourceController();
        CurrentLevel = _gameData.GetLevel();

        var levelObject = _resourceController.GetResource($"Level0") as GameObject;
        _levelGameObject = Instantiate(levelObject);
        MainMenu();
    }

    public void LevelWin()
    {
        GameObject go = _resourceController.GetResource("LevelWinView") as GameObject;
        GameObject.Instantiate(go).GetComponent<LevelWinView>().ChangeText(CurrentLevel);
        CurrentLevel += 1;
        if(CurrentLevel == _resourceController.LastLevel)
        {
            CurrentLevel = 1;
        }
        _gameData.SaveLevel(CurrentLevel);
    }

    public void GameOver()
    {
        GameObject go = _resourceController.GetResource("GameOverView") as GameObject;
        GameObject.Instantiate(go);
    }

    public void ReOpenLevel()
    {
        OpenLevel();
    }

    public void NextLevel()
    {
        OpenLevel();
    }

    public void MainMenu()
    {
        GameObject go = _resourceController.GetResource("MainMenuView") as GameObject;
        GameObject.Instantiate(go);
    }

    public void OpenLevel()
    {
        StartCoroutine(OpenLevelCoroutine());
    }

    private IEnumerator OpenLevelCoroutine()
    {
        //load scene
        SceneManager.LoadScene(1);
        yield return null;
        //load level
        var levelObject = _resourceController.GetResource($"Level{CurrentLevel}") as GameObject;
        _levelGameObject = Instantiate(levelObject);
        //load player
        var playerObject = _resourceController.GetResource("Player") as GameObject;
        _playerController = Instantiate(playerObject).GetComponent<PlayerController>();
        //set Camera followobject
        Camera.main.gameObject.GetComponent<CameraMovement>().FollowTransform = _playerController.Stick;

        //load current level view
        GameObject go = _resourceController.GetResource("CurrentLevelView") as GameObject;
        GameObject.Instantiate(go);

        // if level 1 show tutorial
        if(CurrentLevel == 1)
        {
            TutorialActive = true;
            GameObject.Instantiate(_resourceController.GetResource("TutorialView") as GameObject);
        }
    }
}
