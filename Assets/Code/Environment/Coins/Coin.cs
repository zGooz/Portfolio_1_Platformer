
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public event UnityAction CoinDestroy;

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

            CoinDestroy?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
