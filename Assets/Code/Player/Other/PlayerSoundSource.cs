
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerSoundSource : MonoBehaviour
{
    [SerializeField] private AudioClip step;
    [SerializeField] private AudioClip fall;

    private AudioSource source;
    private PlayerStateMachine machine;
    private JumpState jumpState;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        machine = GetComponent<PlayerStateMachine>();
        jumpState = GetComponent<JumpState>();
    }

    private void OnEnable()
    {
        jumpState.FallToGround += OnPlayFallSound;
    }

    private void OnDisable()
    {
        jumpState.FallToGround -= OnPlayFallSound;
    }

    private void Update()
    {
        if (machine.State == machine.Walk)
        {
            if (source.isPlaying == false)
            {
                Play(step);
            }
        }
    }

    private void OnPlayFallSound()
    {
        Play(fall);
    }

    private void Play(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
