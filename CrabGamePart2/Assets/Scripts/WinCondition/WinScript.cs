using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Crab")
        {
            transform.SetParent(collision.gameObject.transform);
            //go to cutscene
        }
    }
}
