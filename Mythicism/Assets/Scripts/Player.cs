using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Members
    [Header("Controller Data")]
    [SerializeField] public Animator animatorComponent;
    [SerializeField] public CharacterController movementComponent;
    [SerializeField] public Camera cameraComponent;

    [Header("Input Data")]
    private float forwardInput;
    private float rightInput;

    [Header("State Data")]
    [SerializeField] public bool orientRotationToMovement;
    private bool isRolling;

    [Header("Movement Data")]
    [SerializeField] protected float maxMoveSpeed;
    [SerializeField] protected float maxRunSpeed;
    [SerializeField] protected float rotateSpeed;
    [SerializeField] protected Vector3 movementDirection = Vector3.zero;

    #endregion

    #region Behaviors
    // Start is called before the first frame update
    void Start()
    {
        maxMoveSpeed = maxRunSpeed;   
    }
    
    // Update is called once per frame
    void Update()
    {
        ReceiveMovementInput();
        ReceiveDodgeInput();

    }

    private void FixedUpdate()
    {
        UpdateMovement();

        // Update animation parameters
        animatorComponent.SetFloat("ForwardSpeed", Vector3.Dot(movementComponent.velocity, transform.forward) / maxMoveSpeed);
        animatorComponent.SetFloat("RightSpeed", Vector3.Dot(movementComponent.velocity, transform.right) / maxMoveSpeed);
    }

    // Get the latest input from the Dodge button
    private void ReceiveDodgeInput()
    {
        if (Input.GetButtonDown("Dodge"))
        {
            Debug.Log("Dodge received");
            animatorComponent.SetTrigger("Roll");
        }
    }

    // Get the latest input from the Vertical and Horizontal axes
    private void ReceiveMovementInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        rightInput = Input.GetAxis("Horizontal");
    }

    // Update the player's movement based on the latest input
    private void UpdateMovement()
    {
        // Get a forward and right axes relative to camera
        Vector3 cameraForward = cameraComponent.transform.forward;
        Vector3 cameraRight = cameraComponent.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        // Orient rotation to movement
        if(orientRotationToMovement && movementComponent.velocity.magnitude > 0)
        {
            movementDirection = movementComponent.velocity;
            movementDirection.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movementDirection), rotateSpeed * Time.deltaTime);
        }

        // Calculate move direction
        movementDirection = (cameraForward * forwardInput) + (cameraRight * rightInput);

        // Clamp speed
        movementDirection *= maxMoveSpeed;
        float speed = movementDirection.magnitude;
        if (speed > maxMoveSpeed)
            movementDirection = movementDirection.normalized * maxMoveSpeed;

        // Move
        movementComponent.Move(movementDirection * Time.deltaTime);
    }

    private void AddMovementInput(Vector3 worldDirection, float scaleValue, bool orientRotationToMovement = false)
    {
        if(orientRotationToMovement)
        {
            int c = 0;
            
            //Quaternion newRotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime);
        }
        else
            movementComponent.Move(worldDirection * scaleValue * maxMoveSpeed * Time.deltaTime);
    }

    #endregion
}
