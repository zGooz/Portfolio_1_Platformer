
using UnityEngine;
using UnityEngine.Events;


public class DeadArea : MonoBehaviour
{
    public event UnityAction Murder;

    public void OnMurder()
    { 
        Murder?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayer())
        {
            OnMurder();
        }

        bool IsPlayer()
        {
            return collision.gameObject.TryGetComponent(out Player player);
        }
    }
}
