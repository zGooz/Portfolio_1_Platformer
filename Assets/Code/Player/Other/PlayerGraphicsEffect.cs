
using UnityEngine;

public class PlayerGraphicsEffect : MonoBehaviour
{
    [SerializeField] private GameObject dust;
    private JumpState jumpState;
    private PlayerStateMachine machine;
    private GameObject currentDust;

    private void Awake()
    {
        machine = GetComponent<PlayerStateMachine>();
        jumpState = GetComponent<JumpState>();
    }
    private void OnEnable()
    {
        jumpState.FallToGround += OnDustEffectCreate;
    }

    private void OnDisable()
    {
        jumpState.FallToGround -= OnDustEffectCreate;
    }

    private void Update()
    {
        if (machine.State == machine.Walk)
        {
            CreateDust();
        }
    }

    private void OnDustEffectCreate()
    {
        CreateDust();
    }

    private void CreateDust()
    {
        if (currentDust == null)
        {
            currentDust = Instantiate(dust, this.gameObject.transform);
            Destroy(currentDust, 0.7f);
        }
    }
}
