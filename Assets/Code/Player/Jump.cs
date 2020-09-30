
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]

public class Jump : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private GameProcess _managerData;
    private Rigidbody2D _body;
    private BoxCollider2D _collider;
    private Player _player;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _player = GetComponent<Player>();

        _managerData = _player.ManagerStateData;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _player.State = Player.IDLE;
            _sound.Play();
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
                    float _force = _player.JumpForce;

                    _player.State = Player.JUMP;
                    _body.AddForce(new Vector2(0, 1) * _force * Time.deltaTime, ForceMode2D.Impulse);
                }
            }
        }
    }
}
