using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticsUtility;

public class Jump2 : MonoBehaviour
{

    [SerializeField] InputActionReference JumpInput;
    [SerializeField] private float JumpHeight = 2f;

    private CharacterController characterController;
    private Vector3 velocity;

    private float gravity = Physics.gravity.y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        velocity.y += gravity * Time.deltaTime;

        //Apply our move Vector , remeber to multiply by Time.delta
        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        JumpInput.action.performed += Jump;
    }


    private void OnDisable()
    {
        JumpInput.action.performed -= Jump;
    }


    private void Jump(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded)
            ApplyJumpForce();
    }


    private void ApplyJumpForce() 
    {
        //characterController.Move(velocity * JumpHeight);
        velocity.y = Mathf.Sqrt(JumpHeight * -3.0f * gravity);
        Debug.Log("Jump");
        //Move will move charcater in the explicit vector provided.

    }

}
