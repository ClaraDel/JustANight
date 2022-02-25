using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChambreParent : MonoBehaviour
{
    [SerializeField] private GameObject objectifPrefab;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject enfant;

    private GameObject Message;
    private GameObject Message_1;

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
            Message_1.GetComponentInChildren<TMP_Text>().text = "it's too dark outside";
        }
        if (Message_1 != null && Collectables.Instance.CheckObject("flashlight"))
        {
            Message_1.GetComponentInChildren<TMP_Text>().text = "oh no, the flashlight has run out of battery";
        }
        if (Message_1 != null && Collectables.Instance.CheckObject("battery") && Collectables.Instance.CheckObject("battery (1)"))
        {
            Destroy(Message_1);
            Message.GetComponentInChildren<TMP_Text>().text = "You have everything, you can now go outside";
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
        Message = Instantiate(objectifPrefab, panel.transform.position, new Quaternion(0, 0, 0, 0), panel.transform);
        Message.GetComponentInChildren<TMP_Text>().text = "You have to check outside";
        Message_1 = Instantiate(objectifPrefab, panel.transform.position, new Quaternion(0, 0, 0, 0), panel.transform);
        Message_1.GetComponentInChildren<TMP_Text>().text = "You need the key ";
        isActivated = true;
    }

    private void Deactivate()
    {
        Destroy(Message);
        hasBeenActivated = true;
    }
}
