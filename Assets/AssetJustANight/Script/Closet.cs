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

    private void Start()
    {
        door =_Door.GetComponentInChildren<opencloseDoor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated && !hasBeenActivated && _Monster.activeInHierarchy && !door.open)
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
