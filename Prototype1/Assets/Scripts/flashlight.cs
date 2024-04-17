using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Timers;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    Light flashLight;
    public bool isOn;
    public float reduceBattery;
    public float reducePercentage;
    public float batteryLife;
    public float startBatteryFlicker;
    float ogBatteryLife;
    public bool flicker;
    public float flickerTime = 1;
    public float intervalOn = 7.0f;
    public float intervalOff = 0.2f;
    public float interval;

    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponent<Light>();
        reducePercentage = 100;
        reduceBattery = flashLight.intensity;
        batteryLife = 100;
        startBatteryFlicker = 75;
        ogBatteryLife = flashLight.intensity;
        flashLight.enabled = false;
        isOn = false;
        GameData.flashlightOn = false;
        flicker = false;

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && batteryLife > 0)
        {
            flashLight.enabled = !flashLight.enabled;
            isOn = !isOn;
            GameData.flashlightOn = isOn;
        }
    }


    void FixedUpdate()
    {
        if (isOn)
        {
            if (batteryLife > 0)
            {
                if (flashLight.intensity > 1.0f)
                {
                    flashLight.intensity = flashLight.intensity - Time.deltaTime * (10 / reducePercentage);
                }
                if (flicker == false && batteryLife < startBatteryFlicker)
                {
                    flicker = true;


                }

                batteryLife -= Time.deltaTime * reduceBattery;
            }
            else
            {
                isOn = false;
                GameData.flashlightOn = isOn;
                flashLight.enabled = false;
                flicker = false;
            }

            if (flicker)
            {
                flickerTime += Time.deltaTime;
                if (flickerTime > interval)
                {
                    Flicker();
                }
            }
        }
        else
        {
            flicker = false;
            flashLight.enabled = false;
        }

    }

    void Flicker()
    {
        flashLight.enabled = !flashLight.enabled;
        if (!flashLight.enabled)
        {
            interval = Random.Range(0, intervalOff);
        }
        else
        {
            interval = Random.Range(0, intervalOn);
        }

        flickerTime = 0;

    }

}

