
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
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

        State = gameProcess; // applicationRun;
        currentMenu = null;
    }

    public bool HasMenu()
    {
        return currentMenu != null;
    }

    public void CreateElementaryMenu()
    {
        DeleteMenu();
        currentMenu = Instantiate(elementaryMenu);
    }

    public void CreatePauseMenu()
    {
        DeleteMenu();
        currentMenu = Instantiate(pauseMenu);
    }

    public void CreateFinalyMenu()
    {
        DeleteMenu();
        currentMenu = Instantiate(finalyMenu);
    }

    public void DeleteMenu()
    {
        Destroy(currentMenu);
        currentMenu = null;
    }
}
