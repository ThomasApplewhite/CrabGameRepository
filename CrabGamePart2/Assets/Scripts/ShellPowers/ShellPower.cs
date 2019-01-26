using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPower : MonoBehaviour
{

    public GameObject GrapplingHook;
    Vector3 HookOffset;
    // Use this for initialization
    void Start()
    {
        HookOffset = new Vector3(0, 1, 1);
        //Debug.Log("boss SHELL");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Much repreat tonight...");	
    }

    public void Ability()
    {
        Instantiate(GrapplingHook, transform.parent.position + HookOffset, new Quaternion(0, 0, 0, 0));
    }
}