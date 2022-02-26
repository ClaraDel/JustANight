using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    [SerializeField] private GameObject _grenier;
    [SerializeField] private GameObject _Monster;
    [SerializeField] private GameObject _Door;
    private opencloseDoor door;

    private bool isActivated = false;
    private bool hasBeenActivated = false;
    private bool inside = false;

    private void Start()
    {
        door =_Door.GetComponentInChildren<opencloseDoor>();
    }
    private void Update()
    {
        if (inside && !door.open)
        {
            Desactivate(); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated && !hasBeenActivated && _Monster.activeInHierarchy)
        {
            inside = true;
            
        }
    }

    public void Desactivate()
    {
        _grenier.GetComponentInChildren<Grenier>().Deactivate();
        isActivated = true;
    }
}
