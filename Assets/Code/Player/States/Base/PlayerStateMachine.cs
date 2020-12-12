
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerState walk;
    private PlayerState jump;
    private PlayerState idle;

    public PlayerState Walk => walk;
    public PlayerState Jump => jump;
    public PlayerState Idle => idle;

    public PlayerState State { get; set; }

    private void Awake()
    {
        walk = GetComponent<WalkState>();
        jump = GetComponent<JumpState>();
        idle = GetComponent<IdleState>();
        State = Idle;
    }
}
