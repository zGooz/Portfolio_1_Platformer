
using UnityEngine;


public class GameProcess : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _menuGameStarterOrEnder;
    [SerializeField] private GameObject _menuGameResumer;
    [SerializeField] private GameObject _meniGameEnderOrRestarter;

    public GameObject GameStarter => _menuGameStarterOrEnder;
    public GameObject GameResumer => _menuGameResumer;
    public GameObject GameEnderOrRestarter => _meniGameEnderOrRestarter;

    private GameStartOrEnd _gameStarterComponent;

    public const int GAME = 0;
    public const int MENU = 1;
    public const int PAUSE = 2;
    public const int WINNER = 3;
    public const int LOSE = 4;

    public int GameState = MENU;

    private void Awake()
    {
        _menuGameStarterOrEnder = Instantiate(_menuGameStarterOrEnder, _canvas.transform);
        _gameStarterComponent = _menuGameStarterOrEnder.GetComponent<GameStartOrEnd>();
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
        Destroy(_menuGameStarterOrEnder);
    }

    private void OnGameDone()
    {
        Application.Quit();
    }
}
