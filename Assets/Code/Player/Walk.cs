
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]

public class Walk : MonoBehaviour
{
    [SerializeField] private AudioSource soundOfFootsteps;

    private Game main;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Player player;
    private float speed;
    private bool previousFlip;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        main = player.Main;
        speed = player.Speed;
    }

    private void Update()
    {
        if (StateIsOutOfPlay())
        {
            return;
        }

        float axis = Input.GetAxisRaw("Horizontal");

        SetPreviousSpriteFlip();

        if (IsOnGround())
        {
            SetPlayerState(axis);
            // Environment : sound of footsteps, dust, etc...
            CreateCompanionEnvironment(axis);
        }

        SetCurrentSpriteFlip(axis);
        MovingHorizontally(axis);
    }

    private void MovingHorizontally(float axis)
    {
        float scaling = speed * Time.deltaTime;
        Vector2 force = new Vector2(axis, 0) * scaling;

        body.AddForce(force, ForceMode2D.Impulse);
    }

    private void CreateCompanionEnvironment(float axis)
    {
        if (WalkOnGround())
        {
            if (! AxisIsZero(axis))
            {
                createDustAndPlaySoundOfFootsteps();
            }
        }

        bool WalkOnGround()
        {
            return Input.GetButton("Horizontal");
        }
    }

    private bool AxisIsZero(float axis)
    {
        return axis == 0;
    }

    private void SetCurrentSpriteFlip(float axis)
    {
        sprite.flipX = AxisIsZero(axis) ? previousFlip : (axis < 0);
    }

    private void SetPlayerState(float axis)
    {
        player.State = AxisIsZero(axis) ? Player.IDLE : Player.WALK;
    }

    private void SetPreviousSpriteFlip()
    {
        if (StoppedMoving())
        {
            previousFlip = sprite.flipX;
        }

        bool StoppedMoving()
        {
            return Input.GetButtonUp("Horizontal");
        }
    }
    private bool StateIsOutOfPlay()
    {
        return main.State != Game.GAME;
    }

    private bool IsOnGround()
    {
        return player.State != Player.JUMP;
    }

    private void createDustAndPlaySoundOfFootsteps()
    {
        if (! soundOfFootsteps.isPlaying)
        {
            soundOfFootsteps.Play();
            CreateHorstOfDust();
        }

        void CreateHorstOfDust()
        {
            Vector3 placeForCreation = GetDustPosition();
            GameObject dust = Instantiate(player.DustPrefab, placeForCreation, Quaternion.identity);

            Destroy(dust, player.DustLiveTime);
        }

        Vector3 GetDustPosition()
        {
            Vector3 placeForCreation = this.transform.position;

            // For some reason, the dust is not exactly in the center, I had to shift it to the left.
            float x = placeForCreation.x - 0.6f;
            float y = placeForCreation.y;
            float z = placeForCreation.z;

            placeForCreation.Set(x, y, z);

            return placeForCreation;
        }
    }
}
