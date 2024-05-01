using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MainMenuMouse : MonoBehaviour
{

    public Camera FPcamera;
    public LayerMask interactable;
    AudioSource src;



    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        GameData.level = 1;
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
                // DOOR 2
                Debug.Log(raycastHit.transform.name);
            }  

        }

        Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.red);



    }



}

