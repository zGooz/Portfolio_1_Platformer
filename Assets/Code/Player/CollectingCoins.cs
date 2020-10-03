
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]

public class CollectingCoins : MonoBehaviour
{
    [SerializeField] private AudioSource ringingCoins;

    private int coinsAmount;

    public event UnityAction Collecting;

    private void Awake()
    {
        var allCoins = GameObject.FindGameObjectsWithTag("Coins");
        coinsAmount = allCoins.Length;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsCoin())
        {
            PickUpCoin(collision);
        }

        bool IsCoin()
        {
            return collision.gameObject.TryGetComponent(out Coin coin);
        }
    }

    private void PickUpCoin(Collision2D collision)
    {
        coinsAmount -= 1;
        Destroy(collision.gameObject);

        if (CoinNotExists())
        {
            OnCollecting();
        }

        ringingCoins.Play();
    }

    private bool CoinNotExists()
    {
        return coinsAmount == 0;
    }

    public void OnCollecting()
    {
        Collecting?.Invoke();
    }
}
