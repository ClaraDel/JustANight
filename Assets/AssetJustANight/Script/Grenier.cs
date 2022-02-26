using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grenier : MonoBehaviour
{
    [SerializeField] private GameObject objectifPrefab;
    [SerializeField] private GameObject panel;

    private GameObject Message;

    [SerializeField] GameObject _Monster;
    [SerializeField] GameObject CameraOffset;

    private bool isActivated = false;
    private bool hasBeenActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated && !hasBeenActivated && Collectables.Instance.CheckObject("flashlight") && Collectables.Instance.CheckObject("battery"))
        {
            Apparition();
        }
    }

    private void Apparition()
    {
        //Instantiate monster prefab
        _Monster.SetActive(true);
        CameraOffset.GetComponent<Animator>().Play("TrunHeadMonster");
        Message = Instantiate(objectifPrefab, panel.transform.position, new Quaternion(0, 0, 0, 0), panel.transform);
        Message.GetComponentInChildren<TMP_Text>().text = "Lock yourself in your room !!!";
        gameObject.GetComponents<AudioSource>()[0].Play();
        gameObject.GetComponents<AudioSource>()[1].Play();
        isActivated = true;
    }

    

    public void Deactivate()
    {
        hasBeenActivated = true;
        Destroy(Message);
        Destroy(_Monster);
    }
}
