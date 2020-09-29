
using UnityEngine;


[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _gameManager;

    private GameProcess _managerGameProcess;
    private Animator _animator;

    public GameProcess ManagerStateData => _managerGameProcess;
    public float Speed { get; } = 6f;
    public float JumpForce { get; } = 600f;

    public const int IDLE = 0;
    public const int WALK = 1;
    public const int JUMP = 2;

    public int State { get; set; } = IDLE;

    private void Awake()
    {
        _managerGameProcess = _gameManager.GetComponent<GameProcess>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetInteger("State", State);
    }
}
