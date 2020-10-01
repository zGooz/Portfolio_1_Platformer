
using UnityEngine;
using UnityEngine.Events;


public class DeadArea : MonoBehaviour
{
    public event UnityAction Collide;
    public void OnCollide() 
    { 
        Collide?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            OnCollide();
        }
    }
}
