
using UnityEngine;

public class PauseGameState : GameState
{
    private GameStateMachine machine;

    private void Awake()
    {
        machine = GetComponent<GameStateMachine>();
    }

    public override void ExitGame()
    {
        machine.State = machine.GameEndState;

        if (machine.HasMenu())
        {
            machine.DeleteMenu();
        }

        Application.Quit();
    }

    public override void ResumeGame()
    {
        machine.State = machine.GameProcess;

        if (machine.HasMenu())
        {
            machine.DeleteMenu();
        }
    }
}
