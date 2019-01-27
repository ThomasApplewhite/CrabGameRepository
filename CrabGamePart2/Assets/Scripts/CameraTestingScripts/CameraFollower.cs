using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    public Vector3 cameraDirection;  // This gets updated every frame,
                                     // so please don't modify it in other scripts.

    void Start()
    {
        offset = target.transform.position - transform.position;
        cameraDirection = offset.normalized;
    }

    void LateUpdate()
    {
        //float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        target.transform.Rotate(-vertical, 0, 0);

        float desiredAngle_X = target.transform.eulerAngles.x;
        float desiredAngle_Y = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(desiredAngle_X, desiredAngle_Y, 0);
        transform.position = target.transform.position - (rotation * offset);
        cameraDirection = (rotation * offset).normalized;

        transform.LookAt(target.transform);
    }
}
