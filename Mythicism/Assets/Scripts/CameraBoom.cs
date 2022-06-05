using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour
{
    #region Members
    [Header("Controller Data")]
    [SerializeField] public Animator animatorComponent;
    [SerializeField] public CapsuleCollider collisionComponent;
    [SerializeField] public CharacterController movementComponent;
    [SerializeField] public Camera cameraComponent;


    [Header("Movement Data")]
    [SerializeField] protected Vector3 movementDirection = Vector3.zero;
    #endregion


    #region Behaviors
    // Update is called once per frame
    void Update()
    {

    }


    // Start is called before the first frame update
    void Start()
    {

    }
    #endregion
}
