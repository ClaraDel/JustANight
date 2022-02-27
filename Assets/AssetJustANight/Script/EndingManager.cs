using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField] GameObject texts;
    Animator endingAnimator;
    [SerializeField] GameObject text;

    [SerializeField] GameObject menuManager;
    MenuManager menu;
    [SerializeField] AudioClip hauntedSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        menu = menuManager.GetComponent<MenuManager>();
        endingAnimator = texts.GetComponent<Animator>();
        StartCoroutine(waitAfewSeconds());
        StartCoroutine(waitCredits());
        
    }

    IEnumerator waitCredits()
    {
        yield return new WaitForSeconds(23);
        menu.startingGame = true;
        audioSource.Stop();
        Application.LoadLevel(Application.loadedLevel);
    }

    IEnumerator waitAfewSeconds()
    {
        yield return new WaitForSeconds(12);
        text.SetActive(false);
        audioSource.PlayOneShot(hauntedSound);
        endingAnimator.SetBool("doneWaiting", true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
