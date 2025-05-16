using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransport : MonoBehaviour
{
    public Transform targetPosition; // Asignar la caja destino

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetPosition.position; // Teletransportar al Player
            Debug.Log("El jugador fue teletransportado.");
        }
    }

}
