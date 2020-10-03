
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]

public class Jump : MonoBehaviour
{
    [SerializeField] private AudioSource fallingSound;

    private Game main;
    private Rigidbody2D body;
    private Player player;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        main = player.Main;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlatform())
        {
            ToLand();
        }

        void ToLand()
        {
            player.State = Player.IDLE;
            fallingSound.Play();
            CreateHorstOfDust();
        }

        bool IsPlatform()
        {
            return collision.gameObject.TryGetComponent(out Platform platform);
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

    private void Update()
    {
        if (StateIsOutOfPlay())
        {
            return;
        }

        if (! IsAboveGround())
        {
            if (Bounce())
            {
                ToJump();
            }
        }
    }

    private void ToJump()
    {
        float scaling = player.JumpForceScale * Time.deltaTime;
        Vector2 force = new Vector2(0, 1) * scaling;

        player.State = Player.JUMP;
        body.AddForce(force, ForceMode2D.Impulse);
    }

    private bool Bounce()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }

    private bool IsAboveGround()
    {
        return player.State == Player.JUMP;
    }

    private bool StateIsOutOfPlay()
    {
        return main.State != Game.GAME;
    }
}
