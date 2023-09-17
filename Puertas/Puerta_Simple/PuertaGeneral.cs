using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaGeneral : MonoBehaviour
{
   public Animator puerta;
   private bool enZona;
   private bool puertaActiv;

   private bool activa;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enZona == true)
        {
            activa = !activa;

            if(activa == true)
            {
                puerta.SetBool("puertaActiv",true);
            }
            if (activa == false)
            {
                puerta.SetBool("puertaActiv", false);
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerInteractionZone"))
        {
            enZona = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerInteractionZone"))
        {
            enZona = false;
        }
    }
}
