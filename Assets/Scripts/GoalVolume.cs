using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        //GameInput gameInput = other.gameObject.GetComponent<GameInput>();

        if (player != null)
        {
            player.Kill();
            player.Win();
        }
    }
}