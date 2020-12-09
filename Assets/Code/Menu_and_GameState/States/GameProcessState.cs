
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProcessState : MonoBehaviour, IGameState
{
    private GameStateMachine machine;

    private void Awake()
    {
        machine = GetComponent<GameStateMachine>();
    }

    public void PauseGame()
    {
        machine.State = machine.PauseGame;

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
