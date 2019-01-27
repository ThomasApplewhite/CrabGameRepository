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

        if(target.transform.eulerAngles.x - vertical > 285  || target.transform.eulerAngles.x - vertical < 70)
            target.transform.Rotate(-vertical, 0, 0);

        transform.position = target.transform.position - (target.transform.rotation * offset);
        transform.LookAt(target.transform);

        // Let other modules know the current camera direction.
        cameraDirection = (target.transform.rotation * offset).normalized;
    }
}
