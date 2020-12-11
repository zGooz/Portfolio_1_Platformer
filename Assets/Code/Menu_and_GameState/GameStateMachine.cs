
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject elementaryMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject finalyMenu;

    private GameObject currentMenu;

    private IGameState applicationRun;
    private IGameState gameProcess;
    private IGameState pauseGame;
    private IGameState playerDie;
    private IGameState coinFinish;
    private IGameState gameEndState;

    public IGameState State { get; set; }

    public IGameState ApplicationRun => applicationRun;
    public IGameState GameProcess => gameProcess;
    public IGameState PauseGame => pauseGame;
    public IGameState PlayerDie => playerDie;
    public IGameState CoinFinish => coinFinish;
    public IGameState GameEndState => gameEndState;

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

    public void CreateFinalyMenu(IGameState state)
    {
        CreateMenu(finalyMenu, state);
    }

    private void CreateMenu(GameObject menu, IGameState state)
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
