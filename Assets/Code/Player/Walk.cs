
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
        bool stateIsOutPlay = main.State != Game.GAME;
        if (stateIsOutPlay) { return; }
        float axis = Input.GetAxisRaw("Horizontal");
        bool isOnGround = player.State != Player.JUMP;

        SetPreviousSpriteFlipValue();

        if (isOnGround)
        {
            SetState(axis);
            // Environment : sound of footsteps, dust, etc...
            CreateEnvironmentEffect(axis);
        }

        SetCurrentSpriteFlip(axis);
        MovingHorizontally(axis);
    }
    private void SetPreviousSpriteFlipValue()
    {
        bool stoppedMoving = Input.GetButtonUp("Horizontal");
        if (stoppedMoving) { previousFlip = sprite.flipX; }
    }
    private void CreateEnvironmentEffect(float axis)
    {
        bool walkOnGround = Input.GetButton("Horizontal");

        if (walkOnGround && !AxisIsZero(axis))
        {
            createDustAndPlaySoundOfFootsteps();
        }
    }

    private void SetCurrentSpriteFlip(float axis)
    {
        sprite.flipX = AxisIsZero(axis) ? previousFlip : (axis < 0);
    }

    private void MovingHorizontally(float axis)
    {
        float scaling = speed * Time.deltaTime;
        Vector2 force = new Vector2(axis, 0) * scaling;
        body.AddForce(force, ForceMode2D.Impulse);
    }

    private bool AxisIsZero(float axis) { return axis == 0; }

    private void SetState(float axis)
    {
        player.State = AxisIsZero(axis) ? Player.IDLE : Player.WALK;
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
            Vector3 place = GetDustPosition();
            GameObject dust = Instantiate(player.DustPrefab, place, Quaternion.identity);
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
