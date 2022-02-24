using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningControl : MonoBehaviour
{
    float timeDelay;
    float delayBetweenLightning;
    public GameObject[] groupWindows;
    private List<Renderer> renderers;


    private AudioSource audioSource;
    public AudioClip soundLightning;

    public GameObject lightSource1;
    public GameObject lightSource2;



    // Start is called before the first frame update
    void Start()
    {
        renderers = new List<Renderer>();
        for(int i = 0; i < groupWindows.Length; i++)
        {
            renderers.Add(groupWindows[i].GetComponent<Renderer>());
        }
        StartCoroutine(createLightning());
        audioSource = gameObject.GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {

    }

    void changeMaterial(Color color)
    {
        if(renderers.Count != 0)
        {
            for (int i = 0; i < groupWindows.Length; i++)
            {
                renderers[i].material.SetColor("_EmissionColor", color);
            }
        }
        

    }

    IEnumerator createLightning()
    {
        while (true)
        {
            delayBetweenLightning = Random.Range(30, 60);
            yield return new WaitForSeconds(delayBetweenLightning);
            StartCoroutine(emitLight());
            yield return new WaitForSeconds(1.4f);
            if(soundLightning != null)
            {
                audioSource.PlayOneShot(soundLightning, 1f);

            }
        }

    }

   

    

    IEnumerator emitLight()
    {
        // first light
        changeMaterial(Color.white);
        this.gameObject.GetComponent<Light>().enabled = true;
        lightSource1.GetComponent<Light>().enabled = true;
        lightSource2.GetComponent<Light>().enabled = true;

        timeDelay = Random.Range(0.01f,0.1f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = false;
        lightSource1.GetComponent<Light>().enabled = false;
        lightSource2.GetComponent<Light>().enabled = false;


        changeMaterial(Color.clear);


        //Second light
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        lightSource1.GetComponent<Light>().enabled = true;
        lightSource2.GetComponent<Light>().enabled = true;


        changeMaterial(Color.white);

        timeDelay = Random.Range(0.8f, 1.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = false;
        lightSource1.GetComponent<Light>().enabled = false;
        lightSource2.GetComponent<Light>().enabled = false;



        changeMaterial(Color.clear);


    }
}
