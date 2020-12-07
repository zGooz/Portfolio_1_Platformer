
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Menu_and_GameState
{
    public class GameProcessState : MonoBehaviour, IGameState
    {
        private GameStateMachine machine;

        private void Awake()
        {
            machine = GetComponent<GameStateMachine>();
        }

        public void PauseGame()
        {
            machine.State = machine.pauseGame;

            if (!machine.HasMenu())
            {
                machine.CreatePauseMenu();
            }
        }

        public void ReloadGame()
        {
            string scene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        public void ExitGame() {}
        public void StartGame() {}
        public void ResumeGame() {}
    }
}