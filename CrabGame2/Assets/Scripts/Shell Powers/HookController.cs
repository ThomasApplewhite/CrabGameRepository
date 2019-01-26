using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour {

    public GameObject Crab;
    public RigidBody physics;
    bool flying;
	// Use this for initialization
	void Start (int range) {
        //When created, the hook will rotate back and fire a certain distance. It's not effected by gravity, so it'll
        //go in a straigh line.
        physics = GetComponent<RigidBody>;
        transform.Rotate(new Vector3(0, -45, 0));
        physics.AddForce(new Vector3(0, 0, 10 + 10 * range));
        flying = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(Crab.transform.position, transform.position) > range * 10)
        {
            //if the hook gets too far from the crab, it deletes itself.
            Destroy(this);
            //technically, flying is never set to 'false' again, but the script self-destructs when the crab gets there.
            //So it's fine, right?
        }
        if (flying)
        {
            Crab.GetComponent<RigidBody>.AddForce(new Vector3(0, 5, 5));
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == Crab || other.gameObject.CompareTag("Shell"))
        {
            //if the hook hits the crab or the shell, the hook goes away
            Destroy(this);
            //flying = false;
        }
        else
        {
            //if it hits anything else, the crab will fly to the hook. Somehow.
            flying = true;

        }
    }
}
