
using UnityEngine;
using UnityEngine.Events;


public class GameRestartOrEnd : MonoBehaviour
{
    [SerializeField] private GameObject buttonRestart;
    [SerializeField] private GameObject buttonExit;

    private ButtonClick clickForRestart;
    private ButtonClick clickForExit;

    public event UnityAction Restart;
    public event UnityAction Exit;

    private void Awake()
    {
        clickForRestart = buttonRestart.GetComponent<ButtonClick>();
        clickForExit = buttonExit.GetComponent<ButtonClick>();
    }

    private void OnEnable()
    {
        clickForRestart.Click += OnRestartGame;
        clickForExit.Click += OnExitGame;
    }

    private void OnDisable()
    {
        clickForRestart.Click -= OnRestartGame;
        clickForExit.Click -= OnExitGame;
    }

    private void OnRestartGame() { Restart?.Invoke(); }
    private void OnExitGame() { Exit?.Invoke(); }
}
