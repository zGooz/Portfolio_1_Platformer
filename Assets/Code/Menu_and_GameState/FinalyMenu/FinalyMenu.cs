
using UnityEngine;

namespace Assets.Code.Menu_and_GameState.EndGame
{
    public class FinalyMenu : MonoBehaviour
    {
        private GameStateMachine machine;
        [SerializeField] private ButtonClick restart;
        [SerializeField] private ButtonClick end;

        private void Awake()
        {
            machine = FindObjectOfType<GameStateMachine>();
        }
        private void OnEnable()
        {
            restart.Click += machine.State.ReloadGame;
            end.Click += machine.State.ExitGame;
        }

        private void OnDisable()
        {
            restart.Click -= machine.State.ReloadGame;
            end.Click -= machine.State.ExitGame;
        }
    }
}