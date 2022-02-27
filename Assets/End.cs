using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class End : MonoBehaviour
{

    [SerializeField] GameObject Parent;
    [SerializeField] GameObject enfant;
    [SerializeField] GameObject canvas;

    [SerializeField] private GameObject sousTitrePrefab;
    [SerializeField] private GameObject panelTitre;

    public float timeShown ;
    private GameObject sous_titre;
    private string[] conversation ={"Mom : Julien, what are you doing up at this hour ?","I was looking for you, but you weren't there",
        "Dad: What are you saying ? We were in our room !","But no i was ...","Mom : go to bed, Julien.", "But.. I saw a monster !!",
        "MOM: What are you saying ? monster aren't real !" };
    private string message = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Fin()
    {
        Parent.SetActive(true);
        enfant.GetComponent<Animator>().Play("fin");
        //enfant.transform.rotation = new Quaternion(0, 90, 0, 0);
        sous_titre = Instantiate(sousTitrePrefab, panelTitre.transform.position, new Quaternion(0, 0, 0, 0), panelTitre.transform);
        sous_titre.GetComponentInChildren<TMP_Text>().text = conversation[0];
        Invoke("Display_1", 8f);

    }
    void Display_1()
    {
        sous_titre.GetComponentInChildren<TMP_Text>().text = conversation[1];
        Invoke("Display_2", 5f);
    }
    void Display_2()
    {
        sous_titre.GetComponentInChildren<TMP_Text>().text = conversation[2];
        Invoke("Display_3", 4f);
    }
    void Display_3()
    {
        sous_titre.GetComponentInChildren<TMP_Text>().text = conversation[3];
        Invoke("Display_4", 3f);
    }
    void Display_4()
    {
        sous_titre.GetComponentInChildren<TMP_Text>().text = conversation[4];
        Invoke("Display_5", 3f);
    }
    void Display_5()
    {
        sous_titre.GetComponentInChildren<TMP_Text>().text = conversation[5];
        Invoke("Display_6", 3f);
    }
    void Display_6()
    {
        sous_titre.GetComponentInChildren<TMP_Text>().text = conversation[6];
        Invoke("Black", 6f);
    }
    void Black()
    {
        canvas.SetActive(true);
        //Invoke("Quit", 10f);
    }

    private void Quit()
    {
        Application.Quit();
    }

}
