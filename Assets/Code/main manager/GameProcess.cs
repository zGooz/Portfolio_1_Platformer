
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameProcess : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _deadArea;
    [SerializeField] private GameObject _menuGameStarterOrEnderPrefab;
    [SerializeField] private GameObject _menuGameResumerPrefab;
    [SerializeField] private GameObject _meniGameEnderOrRestarterPrefab;

    private GameObject _menuGameStarterOrEnder;
    private GameObject _menuGameResumer;
    private GameObject _meniGameEnderOrRestarter;

    public GameObject GameStarter => _menuGameStarterOrEnder;
    public GameObject GameResumer => _menuGameResumer;
    public GameObject GameEnderOrRestarter => _meniGameEnderOrRestarter;

    private GameStartOrEnd _gameStarterComponent;
    private GameRestartOrEnd _gameEnderComponent;
    private GameResume _gameResumerComponent;

    private CollectingCoins _coinCollectingComponent;
    private DeadArea _areaComponent;

    public const int GAME = 0;
    public const int MENU = 1;
    public const int PAUSE = 2;
    public const int WINNER = 3;
    public const int LOSE = 4;

    public int GameState = MENU;

    private void Awake()
    {
        _menuGameStarterOrEnder = Instantiate(_menuGameStarterOrEnderPrefab, _canvas.transform);
        _gameStarterComponent = _menuGameStarterOrEnder.GetComponent<GameStartOrEnd>();
        _coinCollectingComponent = _player.GetComponent<CollectingCoins>();
        _areaComponent = _deadArea.GetComponent<DeadArea>();
    }

    private void OnEnable()
    {
        _gameStarterComponent.GameRun += OnGameRun;
        _gameStarterComponent.GameDone += OnGameDone;
        _coinCollectingComponent.Collecting += OnWinnder;
        _areaComponent.Collide += OnLoose;
    }

    private void OnDisable()
    {
        _coinCollectingComponent.Collecting -= OnWinnder;
        _areaComponent.Collide -= OnLoose;

        if (_gameEnderComponent is GameRestartOrEnd) 
        {
            _gameEnderComponent.GameRestart -= OnGameRestart;
            _gameEnderComponent.GameDone -= OnGameDone;
        }

        if (_gameResumerComponent is GameResume)
        {
            _gameResumerComponent.ResumeGame -= OnGameResume;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameState == GAME)
            {
                GameState = PAUSE;
                
                _menuGameResumer = Instantiate(_menuGameResumerPrefab, _canvas.transform);
                _gameResumerComponent = _menuGameResumer.GetComponent<GameResume>();
                _gameResumerComponent.ResumeGame += OnGameResume;
            }
        }
    }

    private void OnGameResume()
    {
        GameState = GAME;
        Destroy(_menuGameResumer);
    }

    private void OnWinnder()
    {
        GameState = WINNER;

        _meniGameEnderOrRestarter = Instantiate(_meniGameEnderOrRestarterPrefab, _canvas.transform);
        _gameEnderComponent = _meniGameEnderOrRestarter.GetComponent<GameRestartOrEnd>();

        _gameEnderComponent.GameRestart += OnGameRestart;
        _gameEnderComponent.GameDone += OnGameDone;
    }

    private void OnGameRun()
    {
        GameState = GAME;

        _gameStarterComponent.GameRun -= OnGameRun;
        _gameStarterComponent.GameDone -= OnGameDone;

        Destroy(_menuGameStarterOrEnder);
    }

    private void OnGameRestart()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);

        OnGameRun();
    }

    private void OnLoose()
    {
        OnWinnder();
        GameState = LOSE;
    }

    private void OnGameDone()
    {
        Application.Quit();
    }
}
