using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chambre : MonoBehaviour
{
    [SerializeField] private GameObject objectifPrefab;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject sousTitrePrefab;
    [SerializeField] private GameObject panelTitre;

    private GameObject Message;
    private GameObject sous_titre;

    private bool isActivated = false;
    private bool hasBeenActivated = false;
    bool activateOnStart = true;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated && !hasBeenActivated)
        {
            Activate_Message();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated && !hasBeenActivated)
        {
            Activate();
        }
    }
    public void Activate_Message()
    {
        sous_titre = Instantiate(sousTitrePrefab, panelTitre.transform.position, new Quaternion(0, 0, 0, 0), panelTitre.transform);
        sous_titre.GetComponentInChildren<TMP_Text>().text = "Mom, Dad ?";
        Destroy(sous_titre, 5f);
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
