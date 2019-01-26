using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabProperties : MonoBehaviour {

    public bool ShellOn;
    public GameObject Shell;
	// Use this for initialization
	void Start () {
        ShellOn = false;
	}

    void OnCollisionEnter(Collision shell)
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Shell = shell.gameObject;
            ShellOn = true;
            //something that changes the other thing
        }
    }

    // Update is called once per frame
    void Update () {

        if (ShellOn)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Shell.Get.ComponentTransform.Translate(transfrom.position.x + 5, transform.position.y + 5, transform.position.z + 5);
                //Shell.ShellPower();

            }

        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Doesn't work atm
                Debug.Log("Snip");

            }
           
        }
        
	}

    
}
