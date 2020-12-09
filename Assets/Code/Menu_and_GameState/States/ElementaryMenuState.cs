
using UnityEngine;

public class ElementaryMenuState : MonoBehaviour, IGameState
{
    private GameStateMachine machine;

    private void Awake()
    {
        machine = GetComponent<GameStateMachine>();
    }

    public void StartGame()
    {
        machine.State = machine.GameProcess;

        if (machine.HasMenu())
        {
            machine.DeleteMenu();
        }
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
    public void ReloadGame() {}
    public void ResumeGame() {}
}
