using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class VidaPlayer : MonoBehaviour
{
    public float vida = 100;
    public Image barraVida;

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);

        barraVida.fillAmount = vida / 100;

    }
}
