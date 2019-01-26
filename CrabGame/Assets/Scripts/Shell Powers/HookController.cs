using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour {

    public GameObject Crab;
    public GameObject Tape;
    public Rigidbody physics;
    public float GrappleSpeed;

    bool flying;
    int range;
    int tapeRange;
    Vector3 initialPosition;
    Vector3 direction;

	// Use this for initialization
	void Start () {
        range = 5;
        //When created, the hook will rotate back and fire a certain distance. It's not effected by gravity, so it'll
        //go in a straigh line.
        //physics = GetComponent<rigidbody>();
        Crab = GameObject.FindWithTag("Crab");
        Crab.GetComponent<CrabProperties>().currentHook = this;
        //        transform.Rotate(new Vector3(-45, 0, 0));
        flying = false;
        tapeRange = range;
        initialPosition = transform.position;
        direction = new Vector3(0, 1, 1).normalized;
    }
	
	void FixedUpdate () {
		if(Vector3.Distance(initialPosition, transform.position) >  tapeRange)
        {
            //if the hook gets too far from the crab, it deletes itself.
            Crab.GetComponent<CrabProperties>().currentHook = null;
            Destroy(gameObject);
            //technically, flying is never set to 'false' again, but the script self-destructs when the crab gets there.
            //So it's fine, right?
        }

        if (flying)
        {
            Crab.GetComponent<Rigidbody>().useGravity = false;
            Crab.GetComponent<Transform>().Translate(0.1f * (transform.position - Crab.transform.position).normalized);
            Crab.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Tape.GetComponent<Transform>().position = transform.position + Crab.GetComponent<Transform>().position;
            //big mess rn Tape.GetComponent<Transform>().scale = (new Vector3(1, 0.1f, transform.position 
                //- Crab.GetComponent<Transform>().position));

        /* Tape.GetComponent<Transform>().Translate(transform.position + Crab.GetComponent<Transform>().position);
            Tape.GetComponent<Transform>().localScale += (new Vector3(1, 0.1f, transform.position.z 
                - Crab.GetComponent<Transform>().position.z));
                Some stuff for tape, forget it for now */
        }
        else
        {
            transform.Translate(0.1f * direction);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == Crab || other.gameObject.CompareTag("Shell"))
        {
            if (flying)
            {
                Crab.GetComponent<Rigidbody>().useGravity = true;
                //if the hook hits the crab or the shell, the hook goes away
                Destroy(gameObject);
                //flying = false;
            }
        }
        else
        {
            //if it hits anything else, the crab will fly to the hook. Somehow.
            flying = true;
            Instantiate(Tape, transform.position + Crab.GetComponent<Transform>().position, new Quaternion(0, 0, 0, 0));

        }
    }
}
