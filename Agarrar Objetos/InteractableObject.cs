using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactionCanvas; // Asigna el primer Canvas desde el Inspector
    public GameObject secondInteractionCanvas; // Asigna el segundo Canvas desde el Inspector

    private bool isInteracting = false;

    private void Start()
    {
        interactionCanvas.SetActive(false); // Desactiva el primer Canvas al iniciar
        secondInteractionCanvas.SetActive(false); // Desactiva el segundo Canvas al iniciar
    }

    private void Update()
    {
        if (isInteracting)
        {
            if (Input.GetKey("f"))
            {
                interactionCanvas.SetActive(false); // Desactiva el primer Canvas al interactuar
                secondInteractionCanvas.SetActive(true); // Activa el segundo Canvas al interactuar
                isInteracting = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerInteractionZone"))
        {
            interactionCanvas.SetActive(true); // Activa el primer Canvas de interacción
            isInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerInteractionZone"))
        {
            interactionCanvas.SetActive(false); // Desactiva el primer Canvas de interacción al salir del área
            secondInteractionCanvas.SetActive(false); // Desactiva el segundo Canvas al salir del área
            isInteracting = false;
        }
    }
}
