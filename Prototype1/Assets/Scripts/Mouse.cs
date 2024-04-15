using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public Camera FPcamera;
    public LayerMask interactable;
    public GameObject player;
    public GameObject center;
    public GameObject door2;

    public bool isInRoom;
    public bool isAtDoor;
    public bool doorClosed;
    Vector3 door2Coordinates;
    Vector3 centerCoordinates;

    Collider centerCollider;

    Animator animDoor2;

    // Start is called before the first frame update
    void Start()
    {
        isInRoom = true;
        isAtDoor = false;
        doorClosed = false;
        centerCoordinates = new Vector3(0f, 0.50f, 0f);
        door2Coordinates = new Vector3(7.89f, 0.58f, -4.04f);
        centerCollider = center.GetComponent<Collider>();
        animDoor2 = door2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = FPcamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 200, interactable))
        {
            
            transform.position = raycastHit.point;
            if (Input.GetMouseButtonUp(0) && doorClosed)
            {
                doorClosed = false;
                animDoor2.SetBool("doorClosed", false);
                player.transform.position = door2Coordinates;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(raycastHit.transform.name);
                // if hits a door
                if (raycastHit.transform.CompareTag("Door2") && isInRoom)
                {
                    isInRoom = false;
                    isAtDoor = true;
                    animDoor2.SetBool("isAtDoor", true);
                    player.transform.position = door2Coordinates;
                    centerCollider.enabled = true;
                }
                else if (raycastHit.transform.CompareTag("Door2") && !isInRoom && !doorClosed)
                {
                    doorClosed = true;
                    animDoor2.SetBool("doorClosed", true);
                    player.transform.position = door2Coordinates;
                }
                else if (raycastHit.transform.CompareTag("Center") && isAtDoor)
                {
                    isInRoom = true;
                    isAtDoor = false;
                    centerCollider.enabled = false;
                    animDoor2.SetBool("isAtDoor", false);
                    player.transform.position = centerCoordinates;
                    
                }
            }
            
        }
        
        Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.red);



    }

 

}
