
using UnityEngine;
using UnityEngine.Events;


public class GameResume : MonoBehaviour
{
    [SerializeField] GameObject buttonGameResume;

    private ButtonClick clickToResumeButton;

    public event UnityAction ResumeGame;

    private void Awake()
    {
        clickToResumeButton = buttonGameResume.GetComponent<ButtonClick>();
    }

    private void OnEnable()
    {
        clickToResumeButton.Click += OnGameResume;
    }

    private void OnDisable()
    {
        clickToResumeButton.Click -= OnGameResume;
    }

    private void OnGameResume()
    {
        ResumeGame?.Invoke();
    }
}
