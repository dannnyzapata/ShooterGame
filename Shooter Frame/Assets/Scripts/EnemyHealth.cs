using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float enemyHealth = 100f;
    public static int enemycounterdead = 0;

    private void Start()
    {
        
    }

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;

        if (enemyHealth <= 0) { EnemyDead(); }
    }


    public void EnemyDead()
    {
        Destroy(gameObject);
        enemycounterdead++;
    }
}
