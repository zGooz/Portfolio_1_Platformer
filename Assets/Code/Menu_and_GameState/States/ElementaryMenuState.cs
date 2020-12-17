
using UnityEngine;

public class ElementaryMenuState : GameState
{
    [SerializeField]
    private TemplateMethods templateMethods;
    private GameStateMachine machine;

    private void Awake()
    {
        machine = GetComponent<GameStateMachine>();
    }

    public override void StartGame()
    {
        machine.State = machine.GameProcess;

        if (machine.HasMenu())
        {
            machine.DeleteMenu();
        }
    }

    public override void ExitGame()
    {
        templateMethods.Quit(machine);
    }
}
