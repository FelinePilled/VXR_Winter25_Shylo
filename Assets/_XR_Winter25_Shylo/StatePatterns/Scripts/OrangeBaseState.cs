using UnityEngine;


public abstract class OrangeBaseState
{
    public abstract void EnterState(OrangeStateEditer orange);

    public abstract void UpdateState(OrangeStateEditer orange);

    public abstract void OnCollisionEnter(OrangeStateEditer orange, Collision collision);
}
