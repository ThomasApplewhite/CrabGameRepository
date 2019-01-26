using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyShellBehavior : MonoBehaviour {

    //work with this later. Focus on crab.

    bool ShellOn;
    GameObject Crab;
	// Use this for initialization
	void Start () {
        ShellOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShellPower()
    {
        Debug.Log("Shell!");
    }
}
