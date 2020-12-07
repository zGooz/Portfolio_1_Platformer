
using UnityEngine;

namespace Assets.Code.Player.States
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class WalkState : MonoBehaviour, IPlayerState
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

        public void Walking()
        {
            Move();
        }

        public void Jumping()
        {
            machine.State = machine.Jump;
        }

        public void Nothing() 
        {
            machine.State = machine.Idle;
        }

        private void Move()
        {
            float axis = Input.GetAxisRaw("Horizontal");
            float scaling = player.Speed * Time.deltaTime;
            Vector2 force = new Vector2(axis, 0) * scaling;

            body.AddForce(force, ForceMode2D.Impulse);
        }
    }
}