using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField] GameObject texts;
    Animator endingAnimator;
    [SerializeField] GameObject text;
    [SerializeField] GameObject eventSystem;
    private MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        
        endingAnimator = texts.GetComponent<Animator>();
        StartCoroutine(waitAfewSeconds());
        
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
