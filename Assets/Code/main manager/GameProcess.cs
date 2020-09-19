
using UnityEngine;

public class GameProcess : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _menuGameStarter;
    [SerializeField] private GameObject _menuGameResumer;
    [SerializeField] private GameObject _meniGameEnderOrRestarter;

    public GameObject GameStarter => _menuGameStarter;
    public GameObject GameResumer => _menuGameResumer;
    public GameObject GameEnderOrRestarter => _meniGameEnderOrRestarter;

    private GameStartOrEnd _gameStarterComponent;

    private const int GAME = 0;
    private const int MENU = 1;
    private const int PAUSE = 2;
    private const int WINNER = 3;
    private const int LOSE = 4;

    private int GameState = MENU;

    private void Awake()
    {
        _menuGameStarter = Instantiate(_menuGameStarter, _canvas.transform);
        _gameStarterComponent = _menuGameStarter.GetComponent<GameStartOrEnd>();
    }

    private void OnEnable()
    {
        _gameStarterComponent.GameRun += OnGameRun;
        _gameStarterComponent.GameDone += OnGameDone;
    }

    private void OnDisable()
    {
        _gameStarterComponent.GameRun -= OnGameRun;
        _gameStarterComponent.GameDone -= OnGameDone;
    }

    private void OnGameRun()
    {
        GameState = GAME;
        Destroy(_menuGameStarter);
    }

    private void OnGameDone()
    {
        Application.Quit();
    }
}
