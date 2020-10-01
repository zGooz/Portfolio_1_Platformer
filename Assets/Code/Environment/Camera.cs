
using UnityEngine;


public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private float z;

    private void Awake()
    {
        z = transform.position.z;
    }

    private void Update()
    {
        Vector3 _targetTransform = _target.transform.position;
        transform.position = new Vector3(_targetTransform.x, _targetTransform.y, z);
    }
}
