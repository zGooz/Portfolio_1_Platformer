
using UnityEngine.SceneManagement;

public class PlayerDieState : GameState
{
    public override void ReloadGame()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
