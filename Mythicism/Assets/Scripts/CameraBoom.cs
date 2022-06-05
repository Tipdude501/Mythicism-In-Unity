using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour
{
    #region Members
    [Header("Camera Booom Data")]
    [SerializeField] public Transform target;
    [SerializeField] public float followSmoothTime;
    [SerializeField] public float yawSpeed;
    [SerializeField] public float pitchSpeed;

    [Header("Input Data")]
    private float deltaMouseX;
    private float deltaMouseY;
    #endregion


    #region Behaviors
    // Update is called once per frame
    void Update()
    {
        deltaMouseX = Input.GetAxis("Mouse X");
        deltaMouseY = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        // Follow target
        float velocity = 0;

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.SmoothDamp(newPosition.x, target.position.x, ref velocity, followSmoothTime);
        newPosition.y = Mathf.SmoothDamp(newPosition.y, target.position.y, ref velocity, followSmoothTime);
        newPosition.z = Mathf.SmoothDamp(newPosition.z, target.position.z, ref velocity, followSmoothTime);

        transform.position = newPosition;


        // Rotate with mouse movement
        transform.Rotate(0, deltaMouseX * Time.deltaTime * yawSpeed, 0);
        transform.Rotate(-deltaMouseY * Time.deltaTime * pitchSpeed, 0, 0);
        Vector3 newRotation = transform.rotation.eulerAngles;
        newRotation.z = 0;
      
        transform.rotation = Quaternion.Euler(newRotation);
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    #endregion
}
