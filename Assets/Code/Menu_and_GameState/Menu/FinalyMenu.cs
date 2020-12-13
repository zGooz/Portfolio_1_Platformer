
using UnityEngine;

public class FinalyMenu : MonoBehaviour
{
    private GameStateMachine machine;
    private ButtonClick restart;
    private ButtonClick end;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject endButton;

    private void Awake()
    {
        machine = FindObjectOfType<GameStateMachine>();
        restart = restartButton.GetComponent<ButtonClick>();
        end = endButton.GetComponent<ButtonClick>();
    }
    private void OnEnable()
    {
        restart.Click += machine.State.ReloadGame;
        end.Click += machine.State.ExitGame;
    }

    private void OnDisable()
    {
        restart.Click -= machine.State.ReloadGame;
        end.Click -= machine.State.ExitGame;
    }
}
