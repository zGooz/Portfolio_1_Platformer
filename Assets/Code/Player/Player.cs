
using UnityEngine;
using Assets.Code.Menu_and_GameState;

namespace Assets.Code.Player
{
    public class Player : MonoBehaviour
    {
        private GameStateMachine game;
        private PlayerStateMachine machine;

        public float Speed { get; } = 6.0f;
        public float Shift { get; } = 1.0f;
        public float JumpForce { get; } = 200.0f;

        private void Awake()
        {
            machine = GetComponent<PlayerStateMachine>();
            game = GetComponent<GameStateMachine>();
        }

        public void Walk()
        {
            Execute(machine.State.Walking);
        }

        public void Jump()
        {
            Execute(machine.State.Jumping);
        }

        public void Idle()
        {
            Execute(machine.State.Nothing);
        }

        private void Execute(System.Action method)
        {
            var isGameOut = game.State != game.gameProcess;

            if (!isGameOut)
            {
                method?.Invoke();
            }
        }
    }
}