
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]

public class CollectingCoins : MonoBehaviour
{
    [SerializeField] 
    private AudioSource ringingCoins;
    private int coinsAmount;
    public event UnityAction Collecting;

    private void Awake()
    {
        var coins = GameObject.FindGameObjectsWithTag("Coins");
        coinsAmount = coins.Length;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isCoin = collision.gameObject.TryGetComponent(out Coin coin);
        if (isCoin) { PickUpCoin(collision); }
    }

    private void PickUpCoin(Collision2D collision)
    {
        coinsAmount -= 1;
        Destroy(collision.gameObject);
        bool coinRunOut = coinsAmount == 0;
        if (coinRunOut) { OnCollecting(); }
        ringingCoins.Play();
    }

    public void OnCollecting() { Collecting?.Invoke(); }
}
