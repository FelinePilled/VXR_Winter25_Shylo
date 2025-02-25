using UnityEngine;

public class OrangeWholeState : OrangeBaseState
{

    float rottenCounter = 10.0f;
    public override void EnterState(OrangeStateEditer orange) 
    {
        Debug.Log("Whole State");
        orange.GetComponent<Rigidbody>().useGravity = true;
    }

    public override void UpdateState(OrangeStateEditer orange)
    {
        if (rottenCounter >= 0)
        {
            rottenCounter -= Time.deltaTime;
        }
        else
        {
            orange.SwitchState(orange.RottenState);
        }
    }

    public override void OnCollisionEnter(OrangeStateEditer orange, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<CharacterController>().addHealth();

            orange.SwitchState(orange.ChewedState);
        }
    }

}
