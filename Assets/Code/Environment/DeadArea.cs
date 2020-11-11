
using UnityEngine;
using UnityEngine.Events;


public class DeadArea : MonoBehaviour
{
    public event UnityAction Murder;

    private void OnTriggerExit2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.TryGetComponent(out Player player);
        if (isPlayer) { OnMurder(); }
    }

    public void OnMurder() { Murder?.Invoke(); }
}
