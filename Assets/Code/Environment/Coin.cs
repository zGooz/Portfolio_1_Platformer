
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject starScatteringEffect;

    private float lifetime = 2.0f;
    private GameObject emmiter;

    private void OnDestroy()
    {
        Vector3 placeToCreation = this.transform.position;

        emmiter = Instantiate(starScatteringEffect, placeToCreation, Quaternion.identity);

        Destroy(emmiter, lifetime);
    }

    private void OnApplicationQuit()
    {
        if (IsEmmiterExists())
        {
            Destroy(emmiter);
        }

        bool IsEmmiterExists()
        {
            return emmiter != null;
        }

        Destroy(this);
    }
}
