
using UnityEngine;

namespace Assets.Code.Menu_and_GameState.ElementaryMenu
{
    public class ElementaryMenu : MonoBehaviour
    {
        private GameStateMachine machine;
        [SerializeField] private ButtonClick start;
        [SerializeField] private ButtonClick end;

        private void Awake()
        {
            machine = FindObjectOfType<GameStateMachine>();
        }

        private void OnEnable()
        {
            start.Click += machine.State.StartGame;
            end.Click += machine.State.ExitGame;
        }

        private void OnDisable()
        {
            start.Click -= machine.State.StartGame;
            end.Click -= machine.State.ExitGame;
        }
    }
}