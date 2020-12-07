
using UnityEngine;

namespace Assets.Code.Menu_and_GameState.PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        private GameStateMachine machine;
        [SerializeField] private ButtonClick resume;
        [SerializeField] private ButtonClick end;

        private void Awake()
        {
            machine = FindObjectOfType<GameStateMachine>();
        }

        private void OnEnable()
        {
            resume.Click += machine.State.ResumeGame;
            end.Click += machine.State.ExitGame;
        }

        private void OnDisable()
        {
            resume.Click -= machine.State.ResumeGame;
            end.Click -= machine.State.ExitGame;
        }
    }
}