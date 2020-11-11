
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]

public class Game : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject deathZone;

    [SerializeField] private GameObject gameStarterPrefab;
    [SerializeField] private GameObject gameSuspenserPrefab;
    [SerializeField] private GameObject gameRestareterPrefab;

    [SerializeField] private AudioClip gameRun;
    [SerializeField] private AudioClip gameLosing;
    [SerializeField] private AudioClip gameWinner;

    [SerializeField] private AudioSource audioNotification;
    [SerializeField] private AudioSource backgroundMusic;

    private GameObject gameStarter;
    private GameObject gameSuspenser;
    private GameObject gameRestarter;

    public GameObject GameStarter => gameStarter;
    public GameObject GameResumer => gameSuspenser;
    public GameObject GameEnderOrRestarter => gameRestarter;

    private GameStartOrEnd scriptGameStart;
    private GameRestartOrEnd scriptGameEnd;
    private GameResume scriptGamePause;

    private CollectingCoins scriptCoinCollecting;
    private DeadArea scriptDeathArea;

    public const int GAME = 0;
    public const int MENU = 1;
    public const int PAUSE = 2;
    public const int WINNER = 3;
    public const int LOSE = 4;

    public int State { private set; get; } = MENU;

    private void Awake()
    {
        createMenuBox(ref gameStarter, ref gameStarterPrefab, ref scriptGameStart);

        scriptCoinCollecting = player.GetComponent<CollectingCoins>();
        scriptDeathArea = deathZone.GetComponent<DeadArea>();
        audioNotification = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        scriptGameStart.StartGame += OnGameRun;
        scriptGameStart.ExitGame += OnGameEnd;
        scriptCoinCollecting.Collecting += OnWinnder;
        scriptDeathArea.Murder += OnLoose;
    }

    private void OnDisable()
    {
        scriptCoinCollecting.Collecting -= OnWinnder;
        scriptDeathArea.Murder -= OnLoose;

        if (scriptGameEnd is GameRestartOrEnd) 
        {
            scriptGameEnd.Restart -= OnGameRestart;
            scriptGameEnd.Exit -= OnGameEnd;
        }

        if (scriptGamePause is GameResume)
        {
            scriptGamePause.Resume -= OnGameResume;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (StateIsInGame())
            {
                SetPause();
            }
        }
    }

    private void SetPause()
    {
        State = PAUSE;
        createMenuBox(ref gameSuspenser, ref gameSuspenserPrefab, ref scriptGamePause);
        scriptGamePause.Resume += OnGameResume;
    }

    private void SetWinner()
    {
        State = WINNER;
        createMenuBox(ref gameRestarter, ref gameRestareterPrefab, ref scriptGameEnd);
        scriptGameEnd.Restart += OnGameRestart;
        scriptGameEnd.Exit += OnGameEnd;
    }

    private bool StateIsInGame()
    {
        return State == GAME;
    }

    private void OnGameResume()
    {
        State = GAME;
        Destroy(gameSuspenser);
    }

    private void OnWinnder()
    {
        SetWinner();
        ChangeAndRunSound(audioNotification, gameWinner);
    }

    private void OnGameRun()
    {
        State = GAME;

        scriptGameStart.StartGame -= OnGameRun;
        scriptGameStart.ExitGame -= OnGameEnd;
        Destroy(gameStarter);

        ChangeAndRunSound(audioNotification, gameRun);
    }

    private void OnGameRestart()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);

        OnGameRun();
    }

    private void OnLoose()
    {
        // create Ender_Or_Restarter menu-box
        OnWinnder();
        State = LOSE;
        ChangeAndRunSound(audioNotification, gameLosing);
    }

    private void OnGameEnd()
    {
        Debug.Log("Application.Quit();");
        Application.Quit();
    }

    private void createMenuBox<T>(ref GameObject box, ref GameObject prefab, ref T component)
    {
        box = Instantiate(prefab, canvas.transform);
        component = box.GetComponent<T>();
    }

    private void ChangeAndRunSound(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
