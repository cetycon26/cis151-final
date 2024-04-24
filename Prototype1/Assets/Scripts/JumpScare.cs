using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    
    public float lifetime;
    public bool newStart;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 1.0f;
        newStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (newStart) {
            newStart = false;
            lifetime = 1.0f;
        }
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            newStart = true;
            gameObject.SetActive(false);
        }
    }
}
