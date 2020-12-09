
using UnityEngine;

public class IdleState : MonoBehaviour, IPlayerState
{
    private PlayerStateMachine machine;

    private void Awake()
    {
        machine = GetComponentInParent<PlayerStateMachine>();
    }

    public void Jumping()
    {
        machine.State = machine.Jump;
        machine.State.Jumping();
    }

    public void Walking(float axis)
    {
        machine.State = machine.Walk;
    }

    public void Nothing() {} // <- interface implement
}
