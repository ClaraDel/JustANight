using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public bool isFlickering = false;
    public bool isOn;
    public float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
    }

    void turnOn()
    {
        gameObject.GetComponent<Light>().enabled = true;
    }

    void turnOff()
    {
       gameObject.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            turnOn();
        } else
        {
            turnOff();
        }
    }

}
