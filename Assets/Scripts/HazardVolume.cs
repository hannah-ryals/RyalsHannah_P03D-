using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardVolume : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            playerMovement.Health();
           
        }


    }
}
