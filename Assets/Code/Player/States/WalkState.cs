
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class WalkState : PlayerState
{
    [SerializeField]
    private TemplateMethods templateMethods;
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
        templateMethods.AddForce(body, player.Speed, new Vector2(axis, 0));
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
