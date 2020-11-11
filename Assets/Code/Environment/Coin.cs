
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] 
    private GameObject starScatteringEffect;
    private float lifetime = 2.0f;
    private GameObject emmiter;

    private void OnDestroy()
    {
        Vector3 place = this.transform.position;
        emmiter = Instantiate(starScatteringEffect, place, Quaternion.identity);
        Destroy(emmiter, lifetime);
    }
}
