using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    Color default_color;
    [SerializeField] GameObject sprite;
    // Start is called before the first frame update
    void Start()
    {
        default_color = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeActivate()
    {
        sprite.SetActive(false);
    }
    public void Activate()
    {
        sprite.SetActive(true);
    }
    public void OnRayCastExit()
    {
        GetComponent<Renderer>().material.color = default_color;
    }
}