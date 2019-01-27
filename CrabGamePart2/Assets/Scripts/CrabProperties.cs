using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabProperties : MonoBehaviour
{

    int score;
    //^how many tapes he got
    public Text scoreDisplay;

    public Component ShellPower;
    bool ShellOn;
    public GameObject Shell;
    //^The shell
    public HookController currentHook = null;

    // Use this for initialization
    void Start()
    {
        ShellOn = false;
    }

    void OnCollisionEnter(Collision other)
    //^whenever this collides with a rigidbody...
    {
        if (other.gameObject.CompareTag("Tape") && other.gameObject != Shell)
        {
            score++;
            scoreDisplay.text = "" + score;
            if (score > 1)
            {
                Destroy(other.gameObject);
            }
            else
            {
                ShellOn = true;
                Shell = other.gameObject;
                Shell.GetComponent<Collider>().enabled = false;
                Shell.transform.position = this.transform.position + new Vector3(0, 0f, 0);
                Shell.transform.parent = this.transform;
                Shell.transform.localPosition = new Vector3(0, 0f, 2f);
                Shell.transform.localEulerAngles = new Vector3(10f, 160f, 20f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ShellOn)
        {
            // Check if the player is on the ground by looking for geometry below the player.
            int non_player_layer_mask = ~(1 << 9);
            SphereCollider c = GetComponent<SphereCollider>();
            bool on_ground = Physics.CheckSphere(
                c.bounds.center + new Vector3(0, -c.radius/100, 0),
                c.radius,
                non_player_layer_mask
            );

            if (Input.GetKeyDown(KeyCode.Space) && currentHook == null && on_ground)
            {
                Shell.GetComponent<ShellPower>().Ability();
                //ShellPower();
                //Debug.Log("You have the power!");
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
/*
                --score;
                Shell.GetComponent<Collider>().enabled = true;
                Shell.transform.parent = null;
                Shell.GetComponent<Rigidbody>().AddForce(new Vector3(0, 75, 0));   (???) // This line of code doesn't work because Shell doesn't have a Rigidbody anymore!
                Shell = null;
                ShellOn = false;
                //Resets all shell-related variables and returns the shell to being its own object. Also pops it up
                //and bak a bit. You can juggle your shell, I suppose. The numbers seem big, but the force is
                //only applied for one frame.
*/
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
/*
        if (ShellOn)
        {
            Shell.transform.position = this.transform.position + ShellOffset;
            Shell.transform.rotation = this.transform.rotation;
        }
*/
    }
}
