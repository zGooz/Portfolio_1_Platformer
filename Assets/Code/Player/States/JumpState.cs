
using UnityEngine;

namespace Assets.Code.Player.States
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class JumpState : MonoBehaviour, IPlayerState
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

        public void Jumping()
        {
            Jump();
        }

        public void Walking()
        {
            Shift();
        }

        public void Nothing() {}

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Platform platform))
            {
                machine.State = machine.Idle;
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
}