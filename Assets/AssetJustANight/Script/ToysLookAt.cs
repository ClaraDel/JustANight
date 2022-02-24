using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToysLookAt : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject player;

    public float detectionRange = 5.0f;
    private void FixedUpdate()
    {
        checkPlayerVisibility();

    }

    void checkPlayerVisibility()
    {

        Vector3 ppos = player.transform.position;
        Vector3 dir = (ppos - transform.position).normalized;
        //Shoot a raycast toward the player
        RaycastHit hit;
        bool hitsSomething = Physics.Raycast(transform.position, dir, out hit, detectionRange, layerMask);
        
        if (hitsSomething)
        {
            GameObject objHit = hit.collider.gameObject;
            if (objHit.tag == "Player")
            {
                rotateTowardsPlayer();
            }
        }

    }


    void rotateTowardsPlayer()
    {
        Vector3 baseTargetPostition = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        this.transform.LookAt(baseTargetPostition);
    }
}
