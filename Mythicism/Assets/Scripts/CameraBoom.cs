using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour
{
    #region Members
    [SerializeField] public Transform target;
    [SerializeField] public float followSmoothTime; 
    #endregion


    #region Behaviors
    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float velocity = 0;

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.SmoothDamp(newPosition.x, target.position.x, ref velocity, followSmoothTime);
        newPosition.y = Mathf.SmoothDamp(newPosition.y, target.position.y, ref velocity, followSmoothTime);
        newPosition.z = Mathf.SmoothDamp(newPosition.z, target.position.z, ref velocity, followSmoothTime);

        transform.position = newPosition;
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    #endregion
}
