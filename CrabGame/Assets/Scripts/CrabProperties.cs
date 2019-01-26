using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabProperties : MonoBehaviour {

    bool ShellOn;
    GameObject Shell;
    //Transform crabTransform;
    //public GameObject Shell;
	// Use this for initialization
	void Start () {
        ShellOn = false;
	}

    void OnCollisionEnter(Collision other)
        //^whenever this collides with a rigidbody...
    {
        if (other.gameObject.CompareTag("Shell"))
            //^if it has the shell tag...

        {
            Debug.Log("Shell touch!");
            //^print "Shell touch!" to the console
            ShellOn = true;
            //^set shell on to 'true'
            Shell = other.gameObject;
            //^define that object as 'Shell'
            Shell.transform.Translate(new Vector3(this.transform.position.x + .1f, this.transform.position.y + .1f, 
                this.transform.position.z + .1f));
            //^moves Shell to near this object.
            Shell.transform.parent = this.transform;
            //^make Shell a child of the object this is attached to.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ShellOn)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Shell.ShellPower();
            }else if (Input.GetKey(KeyCode.Mouse1))
            {
                Shell.transform.parent = null;
                Shell = null;
                ShellOn = false;
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
