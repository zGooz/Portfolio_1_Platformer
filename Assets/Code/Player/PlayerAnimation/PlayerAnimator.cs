
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;
    private PlayerStateMachine machine;
    private bool oldFlip;

    private enum EFrame
    {
        IDLE = 0,
        WALK = 1,
        JUMP = 2
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        machine = GetComponent<PlayerStateMachine>();
        animator = GetComponent<Animator>();
        oldFlip = sprite.flipX;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            oldFlip = sprite.flipX;
        }

        if (Input.GetButton("Horizontal"))
        {
            float axis = Input.GetAxisRaw("Horizontal");
            sprite.flipX = axis == 0 ? oldFlip : axis < 0;
        }

        ChangeSprite();
    }

    private void ChangeSprite()
    {
        // Switch not work.
        if (machine.State == machine.Walk)
            animator.SetInteger("State", (int)EFrame.WALK);
        else if (machine.State == machine.Jump)
            animator.SetInteger("State", (int)EFrame.JUMP);
        else if (machine.State == machine.Idle)
            animator.SetInteger("State", (int)EFrame.IDLE);
    }
}
