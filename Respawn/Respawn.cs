using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{   
    VidaPlayer vidaPlayer;
    public float threshold = -5f;
    
    void FixedUpdate() 
  {
    if (vidaPlayer.vida <= 0 || transform.position.y < threshold)
    {
      transform.position = new Vector3(-49.58f, 1.17f, 35.86f);
      vidaPlayer.vida = 100; 
    }
  }
  
  void Start()
  {
    vidaPlayer = GameObject.FindGameObjectWithTag("PlayerInteractionZone").GetComponent<VidaPlayer>(); 
  }
}
