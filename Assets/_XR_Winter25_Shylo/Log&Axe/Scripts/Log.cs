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
    [SerializeField] float m_splitThreshold=6f;
    private float m_stickThreshold = 0f;

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

        if (blade == null) 
            return; //Quit this function earlier if blade script is not found

        if (blade.m_controllerDataReader == null)
            return;

        Split(blade);


    }

    private void Split(Blade blade)
    {
        //Split Log
        float bladeHitSpeed = blade.m_controllerDataReader.Velocity.magnitude;

        if (bladeHitSpeed > m_splitThreshold)
        {

            m_collider.enabled = false;//Disable collision so we can only split once

            EnablePhysics(logOne);
            EnablePhysics(logTwo);
        }

        //Stick Axe
        else if (bladeHitSpeed > m_stickThreshold)
        {
            blade.Drop();
            blade.DisablePhysics();
        }
    }

    void EnablePhysics(GameObject log)
    {
        log.transform.parent = null;

        Rigidbody rg = log.GetComponent<Rigidbody>();
        rg.useGravity = true;
        rg.isKinematic = false;
    }



}