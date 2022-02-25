using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    [SerializeField] private GameObject _grenier;

    private bool isActivated = false;
    private bool hasBeenActivated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated && !hasBeenActivated)
        {
            Activate();
        }
    }

    public void Activate()
    {
        _grenier.GetComponentInChildren<Grenier>().Deactivate();
        isActivated = true;
    }
}
