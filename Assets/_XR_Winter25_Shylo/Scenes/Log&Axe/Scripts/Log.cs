using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


[RequireComponent(typeof(Collider))]

public class Log : MonoBehaviour
{
    [SerializeField] GameObject logOne;
    [SerializeField] GameObject logTwo;

    Collider m_collider = null;




    void Awake()
    {
        m_collider = GetComponent<Collider>();
        m_collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Blade blade = null;
        if (other.CompareTag("Blade"))
        {
            blade = other.GetComponentInParent<Blade>();
        }

        if (blade == null) return; //Quit this function earlier if blade script is not found

        if (blade.m_controllerDataReader == null)
            return;

        Split();


    }

    private void Split()
    {
        //Rigidbody rgOne = logOne.GetComponent<Rigidbody>();
        //Rigidbody rgTwo = logTwo.GetComponent<Rigidbody>();

        //rgOne.useGravity = true;
        //rgOne.isKinematic = false;

        //rgTwo.useGravity = true;
        //rgTwo.isKinematic = false;

        EnablePhysics(logOne);
        EnablePhysics(logTwo);
    }

    void EnablePhysics(GameObject log)
    {
        log.transform.parent = null;
        Rigidbody rg = log.GetComponent<Rigidbody>();

        rg.useGravity = true;
        rg.isKinematic = false;
    }
}