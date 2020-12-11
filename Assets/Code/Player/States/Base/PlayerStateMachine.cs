
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private IPlayerState walk;
    private IPlayerState jump;
    private IPlayerState idle;

    public IPlayerState Walk => walk;
    public IPlayerState Jump => jump;
    public IPlayerState Idle => idle;

    public IPlayerState State { get; set; }

    private void Awake()
    {
        walk = gameObject.AddComponent<WalkState>();
        jump = gameObject.AddComponent<JumpState>();
        idle = gameObject.AddComponent<IdleState>();

        State = Idle;
    }
}
