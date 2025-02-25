using UnityEngine;

public class OrangeRottenState : OrangeBaseState
{
    public override void EnterState(OrangeStateEditer orange)
    {
        if (orange.GetComponent<MeshRenderer>()!= null ) 
        {
            orange.GetComponent<MeshRenderer>().material.color = new Color(0.4f, 0.2f, 0.1f);
        }
    }

    public override void UpdateState(OrangeStateEditer orange)
    {

    }

    public override void OnCollisionEnter(OrangeStateEditer orange, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player")) 
        {
            orange.SwitchState(orange.ChewedState);
        }
    }
}
