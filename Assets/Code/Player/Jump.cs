
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Jump : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private GameProcess _managerData;
    private Rigidbody2D _body;
    private BoxCollider2D _collider;
    private Player _component;

    private float _force;

    private void Start()
    {
        _component = _player.GetComponent<Player>();
        _managerData = _component.ManagerStateData;
        _force = _component.JumpForce;
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_component.PlayerState == Player.JUMP) 
        { 
            if (collision.gameObject.TryGetComponent(out Platform platform))
            {
                _component.PlayerState = Player.IDLE;
            }
        }
    }

    private void Update()
    {
        if (_managerData.GameState == GameProcess.GAME)
        {
            if (_component.PlayerState != Player.JUMP)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    _component.PlayerState = Player.JUMP;
                    _body.AddForce(new Vector2(0, 1) * _force * Time.deltaTime, ForceMode2D.Impulse);
                }
            }
        }
    }
}
