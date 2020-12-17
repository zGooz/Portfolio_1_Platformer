
using UnityEngine;

public class GameProcessState : GameState
{
    [SerializeField]
    private TemplateMethods templateMethods;
    private GameStateMachine machine;

    private void Awake()
    {
        machine = GetComponent<GameStateMachine>();
    }

    public override void PauseGame()
    {
        machine.State = machine.PauseGame;

        if (machine.HasMenu() == false)
        {
            machine.CreatePauseMenu();
        }
    }

    public override void ReloadGame()
    {
        templateMethods.Restart();
    }
}
