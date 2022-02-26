using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Light>().intensity = 0;
        StartCoroutine(turnOn());
    }

    // Update is called once per frame
    IEnumerator turnOn()
    {
        yield return new WaitForSeconds(11f);
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Light>().intensity = 2.5f;
        
    }
}
