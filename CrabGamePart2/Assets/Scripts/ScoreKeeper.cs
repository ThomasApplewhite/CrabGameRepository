using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    int score;
    //how many tapes he got
    public Text scoreDisplay;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Tape"))
        {
            score++;
            scoreDisplay.text = "" + score;
            Destroy(other.gameObject);
        }
    }
}
