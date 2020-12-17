
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class JumpState : PlayerState
{
    [SerializeField]
    private TemplateMethods templateMethods;
    private PlayerStateMachine machine;
    private Rigidbody2D body;
    private Player player;
    private bool isOnGround = true;

    public event UnityAction FallToGround;

    private void Awake()
    {
        machine = GetComponent<PlayerStateMachine>();
        body = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    public override void Jumping()
    {
        if (isOnGround)
        {
            Jump();
            isOnGround = false;
        }
    }

    public override void Walking(float axis)
    {
        Shift();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (isOnGround == false)
                FallToGround?.Invoke();

            machine.State = machine.Idle;
            isOnGround = true;
        }
    }

    private void Shift()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        templateMethods.AddForce(body, player.Shift, new Vector2(axis, 0));
    }

    private void Jump()
    {
        templateMethods.AddForce(body, player.JumpForce, new Vector2(0, 1));
    }
}
