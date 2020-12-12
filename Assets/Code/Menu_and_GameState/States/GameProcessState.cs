
using UnityEngine.SceneManagement;

public class GameProcessState : GameState
{
    private GameStateMachine machine;

    private void Awake()
    {
        machine = GetComponent<GameStateMachine>();
    }

    public override void PauseGame()
    {
        machine.State = machine.PauseGame;

        if (!machine.HasMenu())
        {
            machine.CreatePauseMenu();
        }
    }

    public override void ReloadGame()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
