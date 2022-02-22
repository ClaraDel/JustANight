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

    /*
    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = 2;
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }*/

}
