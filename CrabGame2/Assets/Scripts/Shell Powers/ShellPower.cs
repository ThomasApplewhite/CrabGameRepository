using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPower : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        Debug.Log("boss SHELL");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Much repreat tonight...");	
    }

    public void Ability()
    {
        Debug.Log("much CRUSTACEAN");
        Instantiate(GrapplingHook);
    }
}