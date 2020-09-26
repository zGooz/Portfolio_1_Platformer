
using UnityEngine;
using UnityEngine.Events;


public class CollectingCoins : MonoBehaviour
{
    private int _coinAmount;

    public event UnityAction Collecting;

    private void Awake()
    {
        var array = GameObject.FindGameObjectsWithTag("Coins");
        _coinAmount = array.Length;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _coinAmount -= 1;
            Destroy(collision.gameObject);

            if (_coinAmount == 0) 
            { 
                OnCCollecting(); 
            }
        }
    }

    public void OnCCollecting()
    {
        Collecting?.Invoke();
    }
}
