using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class Carlos_message : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Asignar el objeto de texto
    public TextMeshProUGUI messageText2; // Asignar el objeto de texto

    public Camera playerCamera; // c�mara a desactivar
    public GameObject targetObject; // objeto que queremos activar

    void Start()
    {
        messageText.gameObject.SetActive(true);
        if (targetObject != null)
            targetObject.SetActive(false); // Asegurarse de que el objeto est� desactivado al inicio
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PerformAction();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

    void PerformAction()
    {
        Debug.Log("�Acci�n ejecutada al presionar el gatillo dentro del coche!");

        // Desactivar la c�mara
        if (playerCamera != null)
            playerCamera.gameObject.SetActive(false);

        // Activar el objeto
        if (targetObject != null)
            targetObject.SetActive(true);
        messageText2.text = "Buen viaje"; // Asignar el objeto de texto

    }
}