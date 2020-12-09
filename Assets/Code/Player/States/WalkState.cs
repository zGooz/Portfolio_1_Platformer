
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class WalkState : MonoBehaviour, IPlayerState
{
    private PlayerStateMachine machine;
    private Rigidbody2D body;
    private Player player;

    private void Awake()
    {
        machine = GetComponentInParent<PlayerStateMachine>();
        body = GetComponentInParent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
    }

    public void Walking(float axis)
    {
        float scaling = player.Speed * Time.deltaTime;
        Vector2 force = new Vector2(axis, 0) * scaling;
        body.AddForce(force, ForceMode2D.Impulse);
    }

    public void Jumping()
    {
        machine.State = machine.Jump;
        machine.State.Jumping();
    }

    public void Nothing() 
    {
        machine.State = machine.Idle;
    }
}
