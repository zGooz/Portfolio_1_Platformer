
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _particleSystem;

    private float _liveTime = 2.0f;
    private GameObject _instance;

    private void OnDestroy()
    {
        Vector3 position = this.transform.position;
        position.Set(position.x, position.y, -2);

        _instance = Instantiate(_particleSystem, position, Quaternion.identity);

        Destroy(_instance, _liveTime);
    }

    private void OnApplicationQuit()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }

        Destroy(this);
    }
}
