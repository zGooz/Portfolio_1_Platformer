
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField]
    private GameObject star;
    private Coin coin;
    private readonly float liveTime = 1.6f;

    private void Awake()
    {
        coin = GetComponent<Coin>();
    }

    private void OnEnable()
    {
        coin.CoinDestroy += OnStarEffectCreate;
    }

    private void OnDisable()
    {
        coin.CoinDestroy -= OnStarEffectCreate;
    }

    private void OnStarEffectCreate()
    {
        Vector3 position = this.gameObject.transform.position;

        for (int i = 0; i < 3; i++)
        {
            Destroy(Instantiate(star, position, Quaternion.identity), liveTime);
        }
    }
}
