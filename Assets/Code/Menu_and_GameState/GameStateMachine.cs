
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject elementaryMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject finalyMenu;

    private GameObject currentMenu;

    private GameState applicationRun;
    private GameState gameProcess;
    private GameState pauseGame;
    private GameState playerDie;
    private GameState coinFinish;
    private GameState gameEndState;

    public GameState State { get; set; }

    public GameState ApplicationRun => applicationRun;
    public GameState GameProcess => gameProcess;
    public GameState PauseGame => pauseGame;
    public GameState PlayerDie => playerDie;
    public GameState CoinFinish => coinFinish;
    public GameState GameEndState => gameEndState;

    private void Awake()
    {
        applicationRun = gameObject.AddComponent<ElementaryMenuState>();
        gameProcess = gameObject.AddComponent<GameProcessState>();
        pauseGame = gameObject.AddComponent<PauseGameState>();
        playerDie = gameObject.AddComponent<PlayerDieState>();
        coinFinish = gameObject.AddComponent<CoinNotExistsState>();
        gameEndState = gameObject.AddComponent<GameEndState>();

        State = applicationRun;
        CreateElementaryMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CreatePauseMenu();
        }
    }

    public bool HasMenu()
    {
        return currentMenu != null;
    }

    public void CreateElementaryMenu()
    {
        CreateMenu(elementaryMenu, applicationRun);
    }

    public void CreatePauseMenu()
    {
        CreateMenu(pauseMenu, pauseGame);
    }

    public void CreateFinalyMenu(GameState state)
    {
        CreateMenu(finalyMenu, state);
    }

    private void CreateMenu(GameObject menu, GameState state)
    {
        DeleteMenu();
        State = state;
        currentMenu = Instantiate(menu, canvas.transform);
    }

    public void DeleteMenu()
    {
        Destroy(currentMenu);
        currentMenu = null;
    }
}
