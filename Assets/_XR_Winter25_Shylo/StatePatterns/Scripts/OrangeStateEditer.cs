using NUnit.Framework.Constraints;
using UnityEngine;

public class OrangeStateEditer : MonoBehaviour
{

    OrangeBaseState currentState;
    public OrangeGrowingState GrowingState = new OrangeGrowingState();
    public OrangeChewedState ChewedState = new OrangeChewedState();
    public OrangeRottenState RottenState = new OrangeRottenState();
    public OrangeWholeState WholeState = new OrangeWholeState();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GrowingState;
        currentState.EnterState(this);
    }


    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(OrangeBaseState state) 
    {
        currentState = state;
        state.EnterState(this);
    }


}
