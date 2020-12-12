
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    public virtual void Walking(float axis) {}
    public virtual void Jumping() {}
    public virtual void Nothing() {}
}
