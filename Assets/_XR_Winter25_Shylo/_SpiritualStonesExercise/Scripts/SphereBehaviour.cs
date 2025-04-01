using UnityEngine;
using UnityEngine.InputSystem;

public class SphereBehaviour : MonoBehaviour
{
    //[SerializeField] StoneSocket FireStoneSocket;
    //[SerializeField] StoneSocket ForestStoneSocket;
    //[SerializeField] StoneSocket WaterStoneSocket;

    private void OnEnable()
    {
        StoneSocket.OnAllStonesPlaced += Disappear;
        //ForestStoneSocket.OnAllStonesPlaced += Disappear;
        //WaterStoneSocket.OnAllStonesPlaced += Disappear;
    }

    private void OnDisable()
    {
        StoneSocket.OnAllStonesPlaced -= Disappear;
        //ForestStoneSocket.OnAllStonesPlaced -= Disappear;
        //WaterStoneSocket.OnAllStonesPlaced -= Disappear;
    }

    private void Disappear(StoneSocket socket) 
    {
        gameObject.SetActive(false);
    }

    public void Disappear()
    {
        Debug.Log("Disappear functioon is called");
    }


}


