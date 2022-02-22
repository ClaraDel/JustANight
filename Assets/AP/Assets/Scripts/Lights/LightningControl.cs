using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningControl : MonoBehaviour
{
    float timeDelay;
    float delayBetweenLightning;
    public GameObject groupWindow;
    Renderer renderer;
    private AudioSource audioSource;
    public AudioClip soundLightning;


    // Start is called before the first frame update
    void Start()
    {
        renderer = groupWindow.GetComponent<Renderer>();
        StartCoroutine(createLightning());
        audioSource = gameObject.GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator createLightning()
    {
        while (true)
        {
            delayBetweenLightning = Random.Range(30, 60);
            yield return new WaitForSeconds(delayBetweenLightning);
            StartCoroutine(emitLight());
            yield return new WaitForSeconds(1.4f);
            audioSource.PlayOneShot(soundLightning, 1f);
        }

    }

   

    

    IEnumerator emitLight()
    {
        // first light
        renderer.material.SetColor("_EmissionColor", Color.white);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f,0.1f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = false;
        renderer.material.SetColor("_EmissionColor", Color.clear);

        //Second light
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        renderer.material.SetColor("_EmissionColor", Color.white);
        timeDelay = Random.Range(0.8f, 1.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = false;
        renderer.material.SetColor("_EmissionColor", Color.clear);

    }
}
