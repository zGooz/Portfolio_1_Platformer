
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]

public class Walk : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private GameProcess _managerData;
    private Rigidbody2D _body;
    private SpriteRenderer _renderer;
    private Player _player;

    private float _speed;
    private bool _oldFlip;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();

        _managerData = _player.ManagerStateData;
        _speed = _player.Speed;
    }

    private void Update()
    {
        if (_managerData.GameState == GameProcess.GAME)
        {
            float axis = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonUp("Horizontal"))
            {
                _oldFlip = _renderer.flipX;
            }

            if (_player.State != Player.JUMP)
            {
                _player.State = (axis == 0) ? Player.IDLE : Player.WALK;

                if (Input.GetButton("Horizontal"))
                {
                    if (axis != 0)
                    {
                        if (!_sound.isPlaying)
                        {
                            _sound.Play();
                        }
                    }
                }
            }

            if (axis == 0)
            {
                _renderer.flipX = _oldFlip;
            }
            else
            {
                _renderer.flipX = (axis < 0) ? true : false;
            }

            _body.AddForce(new Vector2(axis, 0) * _speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
