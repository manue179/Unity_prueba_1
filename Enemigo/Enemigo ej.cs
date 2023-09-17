using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigoej : MonoBehaviour
{
    public float rangoDeAlerta = 6;
    public LayerMask capaDeJugador;
    bool estarAlerta;
    public Transform jugador;
    public float velocidad = 4;
    public int cantidadDeDañoPorSegundo = 5; // Cantidad de daño por segundo que el enemigo inflige al jugador

    private bool estaHaciendoDaño;
    private float tiempoDeColision;

    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDeJugador);

        if (estarAlerta)
        {
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {   
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }

    // Detectar colisión con el jugador
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CapsuleCollider>() != null)
        {
            if (!estaHaciendoDaño)
            {
                StartCoroutine(ProducirDaño());
            }
        }
    }

    // Corutina para aplicar daño continuamente mientras el jugador está en contacto
    IEnumerator ProducirDaño()
    {
        estaHaciendoDaño = true;
        tiempoDeColision = Time.time;

        while (Time.time - tiempoDeColision < 1.0f) // Aplicar daño durante 1 segundo
        {
            VidaPlayer vidaPlayer = jugador.GetComponent<VidaPlayer>();
            if (vidaPlayer != null)
            {
                vidaPlayer.vida -= cantidadDeDañoPorSegundo * Time.deltaTime;
            }
            yield return null;
        }

        estaHaciendoDaño = false;
    }
}

