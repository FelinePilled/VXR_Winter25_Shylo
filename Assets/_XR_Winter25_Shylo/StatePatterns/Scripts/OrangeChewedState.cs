using UnityEngine;

public class OrangeChewedState : OrangeBaseState
{
    float destroyCounter = 5.0f;
    
   public override void EnterState(OrangeStateEditer orange)
    {

        Debug.Log("Chewed State");
        if (orange.GetComponent<AudioSource>() != null)
        {
            orange.GetComponent<AudioSource>().Play();
        }
    }

    public override void UpdateState(OrangeStateEditer orange)
    {
        if (destroyCounter > 0)
        {
            destroyCounter -= Time.deltaTime;
        }
        else 
        {
            Object.Destroy(orange.gameObject);
        }

    }

    public override void OnCollisionEnter(OrangeStateEditer orange, Collision collision)
    {

    }
}
