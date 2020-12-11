
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (player.CoinAmount != 1)
                player.CoinAmount -= 1;
            else
            {
                var game = player.GameStateMachine;
                game.State = game.CoinFinish;
                game.CreateFinalyMenu(game.State);
            }
       
            Destroy(this.gameObject);
        }
    }
}
