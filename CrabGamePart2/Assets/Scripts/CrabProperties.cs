using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabProperties : MonoBehaviour
{

    public Component ShellPower;
    bool ShellOn;
    GameObject Shell;
    //^The shell
    Vector3 ShellOffset;
    //^how far the shell is from the rab (or it's position relative to crab)
    public HookController currentHook = null;

    // Use this for initialization
    void Start()
    {
        ShellOn = false;
        ShellOffset = new Vector3(0, .5f, 0);
    }

    void OnCollisionEnter(Collision other)
    //^whenever this collides with a rigidbody...
    {
        if (other.gameObject.CompareTag("Shell"))
        //^if it has the shell tag...

        {
            //Debug.Log("Shell touch!");
            ShellOn = true;
            Shell = other.gameObject;
            Shell.GetComponent<Rigidbody>().useGravity = false;
            Shell.GetComponent<Rigidbody>().freezeRotation = true;
            //ShellPower = 
            Shell.transform.position = this.transform.position + ShellOffset;
            Shell.transform.parent = this.transform;

            /* Does all of these things in this order:
            print "Shell touch!" to the console
            set shell on to 'true'
            define that object as 'Shell'
            disables Shell's gravity (so it doesn't get moved about)
            disables Shell's rotation (so it doesn't spin in midair)
            moves Shell to near this object.
            make Shell a child of the object this is attached to.*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ShellOn)
        {
            if (Input.GetKeyDown(KeyCode.Space) && currentHook == null)
            {
                Shell.GetComponent<ShellPower>().Ability();
                //ShellPower();
                //Debug.Log("You have the power!");
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                Shell.GetComponent<Rigidbody>().useGravity = true;
                Shell.GetComponent<Rigidbody>().freezeRotation = false;
                Shell.transform.parent = null;
                Shell.GetComponent<Rigidbody>().AddForce(new Vector3(0, 75, -75));
                Shell = null;
                ShellOn = false;
                //Resets all shell-related variables and returns the shell to being its own object. Also pops it up
                //and bak a bit. You can juggle your shell, I suppose. The numbers seem big, but the force is
                //only applied for one frame.
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            //depreciated
            //Debug.Log("Snip");
        }

    }

    // LateUpdate is called once after every frame
    void LateUpdate()
    {
        if (ShellOn)
        {
            Shell.transform.position = this.transform.position + ShellOffset;
        }
    }
}
