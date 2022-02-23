using System.Collections;
using UnityEngine;

namespace Assets.AssetJustANight.Script
{
    public class Interaction : MonoBehaviour
    {

        public LayerMask interactionLayer;
        GameObject lastHit;
        RaycastHit hit;
        public float range = 200f;
        private bool interaction = false;
        public float pickUpDistance = 3.0f;

        [SerializeField] Transform player;

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
            
            if (Physics.Raycast(player.position, player.transform.forward, out hit, range, interactionLayer))
            {
                GameObject objHit = hit.collider.gameObject;
                if (objHit.CompareTag("Door") && hit.distance < pickUpDistance)
                {
                    // Tente d'ouvrir la porte si on a utilisé la touche d'interaction
                    if (interaction)
                    {
                        objHit.GetComponent<opencloseDoor>().Open();
                        interaction = false;
                      
                    }
                }
            }
        }
    }
}