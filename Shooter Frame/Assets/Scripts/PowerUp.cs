using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    
    
    public float doublePower = 2f;
    public GameObject pickupEffect;
    // Start is called before the first frame update

  
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Pickup(other);        
        }
    }

    void Pickup(Collider player)
    {
       
        Instantiate(pickupEffect, transform.position, transform.rotation);
       PlayerHealth pistola = player.GetComponent<PlayerHealth>();
       pistola.currentHealth *= doublePower;
       Destroy(gameObject);
    }
}
