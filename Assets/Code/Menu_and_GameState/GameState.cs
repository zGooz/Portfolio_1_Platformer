
using UnityEngine;

public abstract class GameState : MonoBehaviour
{
    public virtual void StartGame() {}
    public virtual void PauseGame() {}
    public virtual void ResumeGame() {}
    public virtual void ReloadGame() {}
    public virtual void ExitGame() {}
}
