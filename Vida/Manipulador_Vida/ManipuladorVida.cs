using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipuladorVida : MonoBehaviour
{
    VidaPlayer vidaPlayer;

    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    void Start()
    {
        vidaPlayer = GameObject.FindGameObjectWithTag("PlayerInteractionZone").GetComponent<VidaPlayer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CapsuleCollider>() != null)
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                vidaPlayer.vida = vidaPlayer.vida + cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }
}
