using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chambre : MonoBehaviour
{
    [SerializeField] private GameObject objectifPrefab;
    [SerializeField] private GameObject panel;

    private GameObject Message;

    private bool isActivated = false;
    private bool hasBeenActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated && !hasBeenActivated)
        {
            Activate();
        }
    }

    public void Activate()
    {
        Message = Instantiate(objectifPrefab, panel.transform.position, new Quaternion(0, 0, 0, 0), panel.transform);
        Message.GetComponentInChildren<TMP_Text>().text = "Go to your parent's bedroom";
        isActivated = true;
    }

    public void Deactivate()
    {
        Destroy(Message);
        hasBeenActivated = true;
    }
}
