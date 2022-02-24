using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringControl : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay = 0;
    public AudioClip switchSound;
    private AudioSource audioSource;
    public GameObject materialOwner1;
    public GameObject materialOwner2;
    Renderer renderer1;
    Renderer renderer2;

    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        renderer1 = materialOwner1.GetComponent<Renderer>();
        originalColor = renderer1.material.GetColor("_EmissionColor");
        renderer2 = materialOwner2.GetComponent<Renderer>();
        originalColor = renderer2.material.GetColor("_EmissionColor");
    }


    // Update is called once per frame
    void Update()
    {
        if (!isFlickering)
        {
            StartCoroutine(FlickeringLight());
            //renderer1.material.SetColor("_EmissionColor", Color.black);

        }
    }


    void PlaySoundInterval(float fromSeconds, float toSeconds)
    {
        audioSource.time = fromSeconds;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
    }


    IEnumerator FlickeringLight()
    {
        isFlickering = true;

        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.2f);
        PlaySoundInterval(0.33f, 0.33f + timeDelay);
        renderer1.material.SetColor("_EmissionColor", Color.black);
        renderer2.material.SetColor("_EmissionColor", Color.black);

        yield return new WaitForSeconds(timeDelay);  
        
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.2f);
        PlaySoundInterval(0.33f, 0.33f + timeDelay);
        renderer1.material.SetColor("_EmissionColor", originalColor);
        renderer2.material.SetColor("_EmissionColor", originalColor);

        yield return new WaitForSeconds(timeDelay);

        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.2f);
        PlaySoundInterval(0.33f, 0.33f + timeDelay);
        renderer1.material.SetColor("_EmissionColor", Color.black);
        renderer2.material.SetColor("_EmissionColor", Color.black);

        yield return new WaitForSeconds(timeDelay);

        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(1f, 4f);
        renderer1.material.SetColor("_EmissionColor", originalColor);
        renderer2.material.SetColor("_EmissionColor", originalColor);

        yield return new WaitForSeconds(timeDelay);

        isFlickering = false;
    }

}
