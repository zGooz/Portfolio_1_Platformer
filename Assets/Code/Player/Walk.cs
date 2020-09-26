
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Walk : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private GameProcess _managerData;
    private Rigidbody2D _body;
    private Player _component;

    private float _speed;

    private void Start()
    {
        _component = _player.GetComponent<Player>();
        _managerData = _component.ManagerStateData;
        _speed = _component.Speed;
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_managerData.GameState == GameProcess.GAME)
        {
            float axis = Input.GetAxisRaw("Horizontal");

            if (_component.PlayerState != Player.JUMP)
            {
                _component.PlayerState = (axis == 0) ? Player.IDLE : Player.WALK;
            }

            _body.AddForce(new Vector2(axis, 0) * _speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
