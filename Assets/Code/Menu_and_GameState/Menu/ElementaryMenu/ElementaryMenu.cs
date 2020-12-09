
using UnityEngine;

public class ElementaryMenu : MonoBehaviour
{
    private GameStateMachine machine;
    private ButtonClick start;
    private ButtonClick end;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject endButton;

    private void Awake()
    {
        machine = FindObjectOfType<GameStateMachine>();
        start = startButton.GetComponent<ButtonClick>();
        end = endButton.GetComponent<ButtonClick>();
    }

    private void OnEnable()
    {
        start.Click += machine.State.StartGame;
        end.Click += machine.State.ExitGame;
    }

    private void OnDisable()
    {
        start.Click -= machine.State.StartGame;
        end.Click -= machine.State.ExitGame;
    }
}
