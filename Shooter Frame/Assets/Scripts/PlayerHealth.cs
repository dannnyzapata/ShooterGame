using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public static PlayerHealth singleton;
    public float currentHealth;
    public float maxHealth = 100f;
    public bool IsDead = false; 

    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void DamagePlayer(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        else
        {
            Dead();
        }
    }

    void Dead()
    {
        currentHealth = 0;
        IsDead = true;
        Debug.Log("Morido");
    }
    
}
