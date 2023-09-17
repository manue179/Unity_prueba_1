using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{   
    Inventario inventario;

    public int valor = 1;
    

    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("PlayerInteractionZone").GetComponent<Inventario>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerInteractionZone")){
            
            inventario.Cantidad = inventario.Cantidad + valor;
            Destroy(gameObject);
        }
    }
}
