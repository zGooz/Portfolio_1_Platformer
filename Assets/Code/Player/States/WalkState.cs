
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class WalkState : PlayerState
{
    private PlayerStateMachine machine;
    private Rigidbody2D body;
    private Player player;

    private void Awake()
    {
        machine = GetComponent<PlayerStateMachine>();
        body = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    public override void Walking(float axis)
    {
        float scaling = player.Speed * Time.deltaTime;
        Vector2 force = new Vector2(axis, 0) * scaling;
        body.AddForce(force, ForceMode2D.Impulse);
    }

    public override void Jumping()
    {
        machine.State = machine.Jump;
        machine.State.Jumping();
    }

    public override void Nothing() 
    {
        machine.State = machine.Idle;
    }
}
