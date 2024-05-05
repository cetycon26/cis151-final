using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{

    
    // Update is called once per frame
    void LateUpdate()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(player.transform);
        transform.rotation = Quaternion.Euler(0f, 180 * transform.rotation.eulerAngles.y, 0f);
    }
}
