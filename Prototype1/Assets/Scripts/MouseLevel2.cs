using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MouseLevel2 : MonoBehaviour
{

    public Camera FPcamera;
    public LayerMask interactable;
    public GameObject player;
    public GameObject center;
    public GameObject door2;
    public GameObject door1;

    public GameObject jumpscare;
    public AudioClip jumpscareSound;
    AudioSource src;

    public bool isInRoom;
    public bool isAtDoor1;
    public bool isAtDoor2;
    public bool doorClosed;
    Vector3 door2Coordinates;
    Vector3 door1Coordinates;
    Vector3 centerCoordinates;


    Collider centerCollider;

    Animator animDoor2;
    Animator animDoor1;

    // Start is called before the first frame update
    void Start()
    {
        isInRoom = true;
        isAtDoor1 = false;
        isAtDoor2 = false;
        doorClosed = false;
        centerCoordinates = new Vector3(0f, 0.50f, 0f);
        door2Coordinates = new Vector3(8.0f, 0.58f, 1.2f);
        door1Coordinates = new Vector3(-8.0f, 0.58f, 0f);
        centerCollider = center.GetComponent<Collider>();
        animDoor2 = door2.GetComponent<Animator>();
        animDoor1 = door1.GetComponent<Animator>();
        src = GetComponent<AudioSource>();
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
                GameData.door1Closed = false;
                GameData.door2Closed = false;
                animDoor2.SetBool("doorClosed", false);
                animDoor1.SetBool("doorClosed", false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                // DOOR 2
                Debug.Log(raycastHit.transform.name);
                // if hits a door
                if (raycastHit.transform.CompareTag("Door2") && isInRoom)
                {
                    isInRoom = false;
                    isAtDoor2 = true;
                    GameData.isAtDoor2 = true;
                    animDoor2.SetBool("isAtDoor", true);
                    player.transform.position = door2Coordinates;
                    // JUMPSCARE
                    if (Random.Range(0,8) == 0) {
                        jumpscare.SetActive(true);
                        src.PlayOneShot(jumpscareSound);

                    }
                    centerCollider.enabled = true;
                }
                else if (raycastHit.transform.CompareTag("Door2") && !isInRoom && !doorClosed)
                {
                    doorClosed = true;
                    GameData.door2Closed = true;
                    animDoor2.SetBool("doorClosed", true);
                }
                // DOOR 1
                else if (raycastHit.transform.CompareTag("Door1") && isInRoom)
                {
                    isInRoom = false;
                    isAtDoor1 = true;
                    GameData.isAtDoor1 = true;
                    animDoor1.SetBool("isAtDoor", true);
                    player.transform.position = door1Coordinates;
                    centerCollider.enabled = true;
                }
                else if (raycastHit.transform.CompareTag("Door1") && !isInRoom && !doorClosed)
                {
                    doorClosed = true;
                    GameData.door1Closed = true;
                    animDoor1.SetBool("doorClosed", true);
                }
                else if (raycastHit.transform.CompareTag("Center"))
                {
                    isInRoom = true;
                    isAtDoor1 = false;
                    GameData.isAtDoor1 = false;
                    isAtDoor2 = false;
                    GameData.isAtDoor2 = false;
                    centerCollider.enabled = false;
                    animDoor2.SetBool("isAtDoor", false);
                    animDoor1.SetBool("isAtDoor", false);
                    player.transform.position = centerCoordinates;

                }
            }

        }

        Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.red);



    }



}
