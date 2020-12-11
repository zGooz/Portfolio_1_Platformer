
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;
    private float z;

    private void Awake() 
    { 
        z = transform.position.z; 
    }

    private void Update()
    {
        Vector3 vector = player.transform.position;
        transform.position = new Vector3(vector.x, vector.y, z);
    }
}
