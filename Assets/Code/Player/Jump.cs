
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Jump : MonoBehaviour
{
    private GameProcess _managerData;
    private Rigidbody2D _body;
    private BoxCollider2D _collider;
    private Player _player;

    private float _force;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _player = GetComponent<Player>();

        _managerData = _player.ManagerStateData;
        _force = _player.JumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _player.State = Player.IDLE;
        }
    }

    private void Update()
    {
        if (_managerData.GameState == GameProcess.GAME)
        {
            if (_player.State != Player.JUMP)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    _player.State = Player.JUMP;
                    _body.AddForce(new Vector2(0, 1) * _force * Time.deltaTime, ForceMode2D.Impulse);
                }
            }
        }
    }
}
