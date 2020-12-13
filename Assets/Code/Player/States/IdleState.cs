
using UnityEngine;

public class IdleState : PlayerState
{
    private PlayerStateMachine machine;

    private void Awake()
    {
        machine = GetComponent<PlayerStateMachine>();
    }

    public override void Jumping()
    {
        machine.State = machine.Jump;
        machine.State.Jumping();
    }

    public override void Walking(float axis)
    {
        machine.State = machine.Walk;
    }
}
