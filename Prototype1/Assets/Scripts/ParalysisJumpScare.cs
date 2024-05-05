using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalysisJumpScare : MonoBehaviour
{

    public GameObject jumpscare;

    // Update is called once per frame
    void Update()
    {
        // If stare too long
        if (ParalysisAI.isParalyzed == true) {
            jumpscare.SetActive(true);
            StartCoroutine(jumpscareEnd());
        }

        // // If paralysis gets too close
        // if (ParalysisAI.paralyzedTime < 3) {
        //     jumpscare.SetActive(true);
        //     StartCoroutine(jumpscareEnd());
        // }

    }

    IEnumerator jumpscareEnd() {
        yield return new WaitForSeconds(4.0f);
        jumpscare.SetActive(false);
    }
}
