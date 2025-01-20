using SerializableCallback;
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class Log : MonoBehaviour
{
    [SerializeField] GameObject LogOne;
    [SerializeField] GameObject LogTwo;

    Collider m_Collider = null;


    private void Awake()
    {
        m_Collider = GetComponent<Collider>();
        m_Collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_Collider != null) 
        {
            Debug.Log("Holy Crap Lois");
        }
    }
    private void Update()
    {
        
    }

}
