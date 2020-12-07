
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Menu_and_GameState.States
{
    public class CoinNotExistsState : MonoBehaviour, IGameState
    {
        private GameStateMachine machine;

        private void Awake()
        {
            machine = GetComponent<GameStateMachine>();
        }

        public void ReloadGame()
        {
            string scene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        public void ExitGame()
        {
            machine.State = machine.gameEndState;

            if (machine.HasMenu())
            {
                machine.DeleteMenu();
            }

            Application.Quit();
        }

        public void PauseGame() {}
        public void StartGame() {}
        public void ResumeGame() {}
    }
}