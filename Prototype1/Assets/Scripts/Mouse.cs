using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public Camera FPcamera;
    public LayerMask interactable;
    public GameObject player;

    public bool isInRoom1;
    public bool isInRoom2;

    // Start is called before the first frame update
    void Start()
    {
        isInRoom1 = true;
        isInRoom2 = false;

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = FPcamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 200, interactable))
        {
            
            transform.position = raycastHit.point;
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(raycastHit.transform.name);
                // if hits a door
                if (raycastHit.transform.CompareTag("Door"))
                {
                    player.transform.position = newLocation();
                }
            }
        }
        
        Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.red);



    }

    Vector3 newLocation()
    {
        Vector3 newCoordinates = new Vector3(0f, 0.58f, 0f);
        if (isInRoom1)
        {
            newCoordinates = new Vector3(18.2f, 0.50f, 0f);
            isInRoom1 = false;
            isInRoom2 = true;
        }
        else
        {
            newCoordinates = new Vector3(0f, 0.50f, 0f);
            isInRoom1 = true;
            isInRoom2 = false;
        }
        return newCoordinates;

    }

}
