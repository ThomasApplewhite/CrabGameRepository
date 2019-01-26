using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour {

    public float MoveSpeed = 10.0f;
    public Rigidbody physics;
	// Use this for initialization
	void Start () {
		
	}
	//x-coord is side-to-side, y-cord is up-down, z-cord is forward-back. Sorta
	// Update is called once per frame
	void Update () {

        //transform.eulerAngles = new Vector3(0.0f, Input.GetAxis("Mouse X") * 20.0f, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            physics.AddForce(new Vector3(0, 0, MoveSpeed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            physics.AddForce(new Vector3(-MoveSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            physics.AddForce(new Vector3(0, 0, -MoveSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            physics.AddForce(new Vector3(MoveSpeed, 0, 0));
        }
    }
}
