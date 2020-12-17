
using UnityEngine;
using UnityEngine.SceneManagement;

public class TemplateMethods : MonoBehaviour
{
    public void Quit(GameStateMachine machine)
    {
        machine.State = machine.GameEndState;

        if (machine.HasMenu())
        {
            machine.DeleteMenu();
        }

        Application.Quit();
        Debug.Log("Application.Quit();");
    }

    public void Restart()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void AddForce(Rigidbody2D body, float value, Vector2 vector)
    {
        float scaling = value * Time.deltaTime;
        Vector2 force = vector * scaling;
        body.AddForce(force, ForceMode2D.Impulse);
    }
}
