
using UnityEngine;

public class DeadArea : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            var game = player.GameStateMachine;
            game.State = game.PlayerDie;
            game.CreateFinalyMenu(game.State);
        }
    }
}
