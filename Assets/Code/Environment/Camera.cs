
using UnityEngine;


public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float z;

    private void Awake()
    {
        z = transform.position.z;
    }

    private void Update()
    {
        Vector3 playerTransform = player.transform.position;

        transform.position = new Vector3(playerTransform.x, playerTransform.y, z);
    }
}
