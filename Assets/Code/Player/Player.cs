
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameStateMachine game;
    private PlayerStateMachine machine;
    private delegate void WalkMethodSignature(float axis); 

    public float Speed { get; } = 7.0f;
    public float Shift { get; } = 2.0f;
    public float JumpForce { get; } = 400.0f;

    private void Awake()
    {
        machine = GetComponent<PlayerStateMachine>();
    }

    private void Update()
    {
        float axis = Input.GetAxisRaw("Horizontal");

        if (axis != 0)
            Walk(axis);
        else
            Idle();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Walk(float axis)
    {
        Execute(machine.State.Walking, axis);
    }

    public void Jump()
    {
        Execute(machine.State.Jumping);
    }

    public void Idle()
    {
        Execute(machine.State.Nothing);
    }

    private void Execute(System.Action method)
    {
        if (!IsGameOut())
        {
            method?.Invoke();
        }
    }

    private void Execute(WalkMethodSignature method, float axis)
    {
        if (! IsGameOut())
        {
            method?.Invoke(axis);
        }
    }

    private bool IsGameOut()
    {
        return game.State != game.GameProcess;
    }
}
