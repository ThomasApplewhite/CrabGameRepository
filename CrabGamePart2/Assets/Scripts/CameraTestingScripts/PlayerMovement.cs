using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float mouseSensitivity;
    public float moveSpeed;
    public float jumpForce;

    AudioSource walkSound;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        walkSound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
        rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));
        if((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && !walkSound.isPlaying)
        {
            walkSound.Play();
        }

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        rb.angularVelocity = new Vector3(rb.angularVelocity.x, 0, 0);
    }
}
