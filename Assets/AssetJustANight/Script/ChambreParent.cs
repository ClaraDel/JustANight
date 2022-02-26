using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChambreParent : MonoBehaviour
{
    [SerializeField] private GameObject objectifPrefab;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject enfant;

    [SerializeField] private GameObject sousTitrePrefab;
    [SerializeField] private GameObject panelTitre;


    private GameObject Message;
    private GameObject Message_1;
    private GameObject sous_titre;

    private bool isActivated = false;
    private bool hasBeenActivated = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void FixedUpdate()
    {
        if (Message_1!=null && Collectables.Instance.CheckObject("rust_key"))
        {
          
            Message_1.GetComponentInChildren<TMP_Text>().text = "it's too dark outside,look for the flashlight";
            Invoke("DeleteMessage", 8f);
        }
        if (Message_1 != null && Collectables.Instance.CheckObject("flashlight"))
        {
            sous_titre.GetComponentInChildren<TMP_Text>().text = "oh no, the flashlight has run out of battery";
            Message_1.GetComponentInChildren<TMP_Text>().text = "You have to find the battery";
            Invoke("DeleteMessage", 8f);
        }
        if (Message_1 != null && Collectables.Instance.CheckObject("battery") && Collectables.Instance.CheckObject("battery (1)"))
        {
            Destroy(Message_1);
          
            sous_titre.GetComponentInChildren<TMP_Text>().text = "I can go see if my parents are outside";
            Message.GetComponentInChildren<TMP_Text>().text = "Go outside";
            Invoke("DeleteMessage", 8f);
            Invoke("Deactivate", 4f);
        }
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
        enfant.GetComponentInChildren<Chambre>().Deactivate();
        sous_titre = Instantiate(sousTitrePrefab, panelTitre.transform.position, new Quaternion(0, 0, 0, 0), panelTitre.transform);
        sous_titre.GetComponentInChildren<TMP_Text>().text = "There are not here... Maybe outside ?";
        Message = Instantiate(objectifPrefab, panel.transform.position, new Quaternion(0, 0, 0, 0), panel.transform);
        Message.GetComponentInChildren<TMP_Text>().text = "You have to check outside, you need to find the key";
        Invoke("DeleteMessage", 8f);
        Message_1 = Instantiate(objectifPrefab, panel.transform.position, new Quaternion(0, 0, 0, 0), panel.transform);
        Message_1.GetComponentInChildren<TMP_Text>().text = "Find the key ";
        isActivated = true;
       
    }

    private void Deactivate()
    {
        Destroy(Message);
        hasBeenActivated = true;
    }

    void DeleteMessage()
    {
        sous_titre.GetComponentInChildren<TMP_Text>().text = "";
    }
}
