
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
        jumpState.DropDown += OnCreateDust;
    }

    private void OnDisable()
    {
        jumpState.DropDown -= OnCreateDust;
    }

    private void Update()
    {
        if (machine.State == machine.Walk)
        {
            CreateDust();
        }
    }

    private void OnCreateDust()
    {
        CreateDust();
    }

    private void CreateDust()
    {
        if (currentDust == null)
        {
            currentDust = Instantiate(dust, this.gameObject.transform);
            Destroy(currentDust, 0.5f);
        }
    }
}
