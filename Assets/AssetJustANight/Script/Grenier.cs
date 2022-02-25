using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grenier : MonoBehaviour
{
    [SerializeField] string textToDisplay;
    [SerializeField] Text textArea;


    private bool isActivated = false;
    private bool hasBeenActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //if (objectif rempli && isActivated )
        //{
        //Deactivate();
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated && !hasBeenActivated)
        {
           Apparition();
        }
    }

    private void Apparition()
    {
        //Instantiate monster prefab
        //play animation
        //if monster touch player -> reset game
    }

    public void Activate()
    {
        isActivated = true;
        textArea.text = textToDisplay;
        textArea.gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        hasBeenActivated = true;
        textArea.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
