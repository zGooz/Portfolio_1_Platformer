
using UnityEngine;

public class CoinNotExistsState : GameState
{
    [SerializeField]
    private TemplateMethods templateMethods;
    private GameStateMachine machine;

    private void Awake()
    {
        machine = GetComponent<GameStateMachine>();
    }

    public override void ReloadGame()
    {
        templateMethods.Restart();
    }

    public override void ExitGame()
    {
        templateMethods.Quit(machine);
    }
}
