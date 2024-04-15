using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{

    public Camera FPCamera;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(FPCamera.transform);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
