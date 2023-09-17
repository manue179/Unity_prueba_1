using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Daño por enemigo");
        }
    }
}
