
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
        walk = gameObject.AddComponent<WalkState>();
        jump = gameObject.AddComponent<JumpState>();
        idle = gameObject.AddComponent<IdleState>();

        State = Idle;
    }
}
