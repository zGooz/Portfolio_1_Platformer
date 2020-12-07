
using UnityEngine;

namespace Assets.Code.Player.States
{
    public class IdleState : MonoBehaviour, IPlayerState
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
            machine.State = machine.Jump;
        }

        public void Walking()
        {
            machine.State = machine.Walk;
        }

        public void Nothing() {}

    }
}