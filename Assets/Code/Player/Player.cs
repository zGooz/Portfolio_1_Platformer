
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField] GameObject _gameManager;

    private GameProcess _managerGameProcess;

    public GameProcess ManagerStateData => _managerGameProcess;
    public float Speed { get; } = 6f;
    public float JumpForce { get; } = 500f;

    public const int IDLE = 0;
    public const int WALK = 1;
    public const int JUMP = 2;

    public int PlayerState { get; set; } = IDLE;

    private void Awake()
    {
        _managerGameProcess = _gameManager.GetComponent<GameProcess>();
    }
}
