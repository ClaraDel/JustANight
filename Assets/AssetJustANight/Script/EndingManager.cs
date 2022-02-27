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

    // Start is called before the first frame update
    void Start()
    {
        menu = menuManager.GetComponent<MenuManager>();
        endingAnimator = texts.GetComponent<Animator>();
        StartCoroutine(waitAfewSeconds());
        StartCoroutine(waitCredits());
        
    }

    IEnumerator waitCredits()
    {
        yield return new WaitForSeconds(23);
        menu.startingGame = true;
        Application.LoadLevel(Application.loadedLevel);
    }

    IEnumerator waitAfewSeconds()
    {
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        endingAnimator.SetBool("doneWaiting", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
