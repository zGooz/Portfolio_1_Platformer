
using UnityEngine;
using UnityEngine.Events;


public class GameResume : MonoBehaviour
{
    [SerializeField] 
    private GameObject button;
    private ButtonClick component;
    public event UnityAction Resume;

    private void Awake()
    {
        component = button.GetComponent<ButtonClick>();
    }

    private void OnEnable() { component.Click += OnGameResume;}
    private void OnDisable() { component.Click -= OnGameResume; }
    private void OnGameResume() { Resume?.Invoke(); }
}
