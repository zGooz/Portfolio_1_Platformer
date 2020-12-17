
using UnityEngine;

public class PauseGameState : GameState
{
    [SerializeField]
    private TemplateMethods templateMethods;
    private GameStateMachine machine;

    private void Awake()
    {
        machine = GetComponent<GameStateMachine>();
    }

    public override void ExitGame()
    {
        templateMethods.Quit(machine);
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
