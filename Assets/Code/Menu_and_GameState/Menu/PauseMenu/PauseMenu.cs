
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameStateMachine machine;
    private ButtonClick resume;
    private ButtonClick end;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject endButton;

    private void Awake()
    {
        machine = FindObjectOfType<GameStateMachine>();
        resume = resumeButton.GetComponent<ButtonClick>();
        end = endButton.GetComponent<ButtonClick>();
    }

    private void OnEnable()
    {
        resume.Click += machine.State.ResumeGame;
        end.Click += machine.State.ExitGame;
    }

    private void OnDisable()
    {
        resume.Click -= machine.State.ResumeGame;
        end.Click -= machine.State.ExitGame;
    }
}
