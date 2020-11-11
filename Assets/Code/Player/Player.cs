
using UnityEngine;


[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject dust;

    private CollectingCoins cionComponent;
    private Animator animator;
    private const float JUMP_FORCE_MAX = 550.0f;
    private const float JUMP_FORCE_MIN = 400.0f;
    private const float SPEED = 5.0f;

    public const int IDLE = 0;
    public const int WALK = 1;
    public const int JUMP = 2;

    public Game Main => main.GetComponent<Game>();
    public GameObject DustPrefab => dust;
    public float Speed { private set; get; } = SPEED;
    public float JumpForceScale { private set; get; } = JUMP_FORCE_MAX;
    public float DustLiveTime { get; } = 0.5f;
    public int State { get; set; } = IDLE;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        cionComponent = GetComponent<CollectingCoins>();
    }

    private void Update()
    {
        ChangeSprite();
        AdjustForceValue();
    }

    private void OnEnable() { cionComponent.Collecting += OnCoinNotExists; }
    private void OnDisable() { cionComponent.Collecting -= OnCoinNotExists; }
    private void OnCoinNotExists() { State = IDLE; }

    private void AdjustForceValue()
    {
        var isWalk = State == WALK;
        JumpForceScale = isWalk ? JUMP_FORCE_MIN : JUMP_FORCE_MAX;
    }

    private void ChangeSprite() { animator.SetInteger("State", State); }
}
