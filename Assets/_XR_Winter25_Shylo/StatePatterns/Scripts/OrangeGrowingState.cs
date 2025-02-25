using UnityEngine;

public class OrangeGrowingState : OrangeBaseState
{

    Vector3 startingOrangeSize = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 growOrangeScalar = new Vector3(0.1f, 0.1f, 0.1f);

    public override void EnterState(OrangeStateEditer orange)
    {
        Debug.Log("Growing State");
        orange.transform.localScale = startingOrangeSize;
    }

    public override void UpdateState(OrangeStateEditer orange)
    {
        if (orange.transform.localScale.x < 1) 
        {
            orange.transform.localScale += growOrangeScalar * Time.deltaTime;
        }
        else
        {
            orange.SwitchState(orange.WholeState);
        }
    }

    public override void OnCollisionEnter(OrangeStateEditer orange, Collision collision)
    {

    }

}
