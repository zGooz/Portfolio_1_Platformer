
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class JumpState : MonoBehaviour, IPlayerState
{
    private PlayerStateMachine machine;
    private Rigidbody2D body;
    private Player player;
    private bool isOnGround = true;

    private void Awake()
    {
        machine = GetComponentInParent<PlayerStateMachine>();
        body = GetComponentInParent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
    }

    public void Jumping()
    {
        if (isOnGround)
        {
            Jump();
            isOnGround = false;
        }
    }

    public void Walking(float axis)
    {
        Shift();
    }

    public void Nothing() {} // <- interface implement

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            machine.State = machine.Idle;
            isOnGround = true;
        }
    }

    private void Shift()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        AddForce(player.Shift, new Vector2(axis, 0));
    }

    private void Jump()
    {
        AddForce(player.JumpForce, new Vector2(0, 1));
    }

    private void AddForce(float value, Vector2 vector)
    {
        float scaling = value * Time.deltaTime;
        Vector2 force = vector * scaling;
        body.AddForce(force, ForceMode2D.Impulse);
    }
}
