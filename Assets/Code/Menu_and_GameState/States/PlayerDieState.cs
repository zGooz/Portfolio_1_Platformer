
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDieState : MonoBehaviour, IGameState
{
    public void ReloadGame()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void ExitGame() {}
    public void PauseGame(){}
    public void StartGame() {}
    public void ResumeGame(){}
}
