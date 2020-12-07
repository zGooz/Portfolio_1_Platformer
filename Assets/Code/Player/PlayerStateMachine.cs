
using Assets.Code.Player.States;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        public readonly IPlayerState Walk;
        public readonly IPlayerState Jump;
        public readonly IPlayerState Idle;

        public IPlayerState State { get; set; }

        public PlayerStateMachine()
        {
            Walk = GetComponent<WalkState>();
            Jump = GetComponent<JumpState>();
            Idle = GetComponent<IdleState>();

            State = Idle;
        }
    }
}
