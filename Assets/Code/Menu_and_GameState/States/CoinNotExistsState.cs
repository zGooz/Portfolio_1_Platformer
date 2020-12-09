
using UnityEngine;
using UnityEngine.SceneManagement;

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
        machine.State = machine.GameEndState;

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
