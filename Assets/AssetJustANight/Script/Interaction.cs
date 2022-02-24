using System.Collections;
using UnityEngine;

namespace Assets.AssetJustANight.Script
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] Material color;
        public LayerMask interactionLayer;
        GameObject lastHit;
        RaycastHit hit;
        public float range = 200f;
        private bool interaction = false;
        public float pickUpDistance = 3.0f;

        [SerializeField] Transform player;
        [SerializeField] Camera cam;

        // Use this for initialization
        void Start()
        {

        }
        private void Update()
        {
            if (!interaction)
            {
                //interaction = Input.GetButtonDown("Interaction");
                interaction = Input.GetMouseButtonDown(0);
            }
        }
        // Update is called once per frame
        private void FixedUpdate()
        {
            //Crée un vecteur au centre de la vue de la caméra
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, range, interactionLayer))
            {
                GameObject objHit = hit.collider.gameObject;
                if ((lastHit != null) && (lastHit != hit.collider.gameObject) && (lastHit.layer == LayerMask.NameToLayer("Collectable")))
                {
                    lastHit.GetComponent<HighLight>().OnRayCastExit();
                    lastHit.GetComponent<HighLight>().DeActivate();
                }
                // ..ou si l'on est trop loin de celui-ci
                if (objHit.layer == LayerMask.NameToLayer("Collectable") && hit.distance > pickUpDistance)
                {
                    objHit.GetComponent<HighLight>().OnRayCastExit();
                    objHit.GetComponent<HighLight>().DeActivate();
                }
                
                if (objHit.CompareTag("object"))
                {
                    // Vérifie que l'on ne soit pas trop éloigné
                    if (hit.distance < pickUpDistance)
                    {
                        //Change material de l'objets
                        Renderer rend = objHit.GetComponent<Renderer>();
                        objHit.GetComponent<HighLight>().Activate();
                        rend.material.color = color.color;
                        print("ok");
                        // Ramasse l'objet si on a utilisé la touche d'interaction
                        if (interaction)
                        {
                            print("Item " + objHit.name + " collecté");
                            Collectables.Instance.AddObject(objHit.name);
                            
                            Destroy(objHit);
                            //UITextManager.Instance.PrintText("Item " + objHit.name + " collecté");
                        }
                    }
                }
                if (objHit.CompareTag("Door") && hit.distance < pickUpDistance)
                {
                    objHit.GetComponentInChildren<HighLight>().Activate();
                    // Tente d'ouvrir la porte si on a utilisé la touche d'interaction
                    if (interaction)
                    {
                        objHit.GetComponentInChildren<HighLight>().DeActivate();
                        objHit.GetComponent<opencloseDoor>().Open();
                        

                    }
                    
                }
                lastHit = objHit;
            }
            else
            {
                // Si on a rien touché et que l'ancien objet touché était un collectable, remet son material par défaut
                if (lastHit != null && lastHit.layer == LayerMask.NameToLayer("Collectable"))
                {
                    lastHit.GetComponent<HighLight>().OnRayCastExit();
                    lastHit.GetComponent<HighLight>().DeActivate();
                    lastHit = null;
                }
            }
            interaction = false;
        }
    }
           
}