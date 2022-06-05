using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Members
    [Header("Controller Data")]
    [SerializeField] public Animator animatorComponent;
    [SerializeField] public CapsuleCollider collisionComponent;
    [SerializeField] public CharacterController movementComponent;
    [SerializeField] public Camera cameraComponent;


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
        UpdateMovement();
    }

    // Update the player's movement based on the Vertical and Horiztonal axes
    private void UpdateMovement()
    {
        // Get input axes
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");

        // Get a forward and right axes relative to camera
        Vector4 cameraZAxis = transform.worldToLocalMatrix.inverse.GetRow(2);
        Vector4 cameraXAxis = transform.worldToLocalMatrix.inverse.GetRow(0);
        Vector3 cameraForward = new Vector3(cameraZAxis.x, cameraZAxis.y, cameraZAxis.z).normalized;
        Vector3 cameraRight = new Vector3(cameraXAxis.x, cameraXAxis.y, cameraXAxis.z).normalized;

        // Orient rotation to forward movement
        if(forwardInput > 0)
        {

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
