
using UnityEngine;


[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _gameManager;
    [SerializeField] private GameObject _dust;

    private CollectingCoins _coinCollectingComponent;
    private GameProcess _managerGameProcess;
    private Animator _animator;

    private const float JUMP_FORCE_MAX = 550.0f;
    private const float JUMP_FORCE_MIN = 400.0f;
    private const float SPEED = 5.0f;

    public GameProcess ManagerStateData => _managerGameProcess;
    public float Speed { private set; get; } = SPEED;
    public float JumpForce { private set; get; } = JUMP_FORCE_MAX;

    public GameObject GetDustPrefab => _dust;
    public float DustLiveTime { get; } = 0.5f;

    public const int IDLE = 0;
    public const int WALK = 1;
    public const int JUMP = 2;

    public int State { get; set; } = IDLE;

    private void OnEnable()
    {
        _coinCollectingComponent.Collecting += OnCoinNotExists;
    }

    private void OnDisable()
    {
        _coinCollectingComponent.Collecting -= OnCoinNotExists;
    }

    private void OnCoinNotExists()
    {
        State = IDLE;
    }

    private void Awake()
    {
        _managerGameProcess = _gameManager.GetComponent<GameProcess>();
        _animator = GetComponent<Animator>();
        _coinCollectingComponent = GetComponent<CollectingCoins>();
    }

    private void Update()
    {
        _animator.SetInteger("State", State);
        JumpForce = (State == WALK) ? JUMP_FORCE_MIN : JUMP_FORCE_MAX;
    }
}
