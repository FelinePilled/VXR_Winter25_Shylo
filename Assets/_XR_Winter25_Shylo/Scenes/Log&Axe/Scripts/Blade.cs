using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;
using System;



[RequireComponent(typeof(XRGrabInteractable))]


public class Blade : MonoBehaviour
{
    public XRGrabInteractable m_GrabInteractable;
    public ControllerDataReader m_ControllerDataReader;
    XRBaseInteractor m_interactor;


    private void Awake()
    {
        m_GrabInteractable = GetComponent<XRGrabInteractable>();

    }

    private void OnEnable()
    {
        if (m_GrabInteractable == null)
            return;
        m_GrabInteractable.selectEntered.AddListener(OnSelectEnter);
        m_GrabInteractable.selectExited.AddListener(ResetControllerDataReader);
    }

    private void ResetControllerDataReader(SelectExitEventArgs arg0)
    {
        m_ControllerDataReader = null;
    }

    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        //ser to interactor that is grabbing the axe
        m_interactor = arg0.interactorObject as XRBaseInteractor;

        //set the controller data reader
        m_ControllerDataReader = m_interactor.gameObject.GetComponentInParent<ControllerDataReader>();
    }

    private void OnDisable()
    {
        if (m_GrabInteractable == null)
            return;
        m_GrabInteractable.selectEntered.RemoveListener(OnSelectEnter);
        m_GrabInteractable.selectExited.RemoveListener(ResetControllerDataReader);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
