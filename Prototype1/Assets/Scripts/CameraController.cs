using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of camera rotation
    public float maxYRotation = 80f; // Maximum rotation around x-axis (looking down)
    public float minYRotation = -80f; // Minimum rotation around x-axis (looking up)
    public float alreadyRotated;
    public float potentialRotation;
    public float rotationAmount;

    void Start()
    {
        alreadyRotated = 0f;
        potentialRotation = 0f;

    }

    void Update()
    {
        // Get input for vertical rotation (up/down)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the amount of rotation based on input
        rotationAmount = -verticalInput * rotationSpeed * Time.deltaTime;
        potentialRotation = alreadyRotated + rotationAmount;

        if (potentialRotation <= maxYRotation && potentialRotation >= minYRotation)
        {
            alreadyRotated += rotationAmount;
            transform.Rotate(rotationAmount, 0, 0);
        }


    }


}
