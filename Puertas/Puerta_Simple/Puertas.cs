using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject interactionCanvas; // Asigna el Canvas desde el Inspector

    private bool isInteracting = false;

    private void Start()
    {
        interactionCanvas.SetActive(false); // Desactiva el Canvas al iniciar
    }

    private void Update()
    {
        if (isInteracting)
        {
            if (Input.GetKey("e")) 
            {
                interactionCanvas.SetActive(false); // Desactiva el Canvas al interactuar
                isInteracting = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerInteractionZone"))
        {
            interactionCanvas.SetActive(true); // Activa el Canvas de interacción
            isInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerInteractionZone"))
        {
            interactionCanvas.SetActive(false); // Desactiva el Canvas de interacción al salir del área
            isInteracting = false;
        }
    }
}
