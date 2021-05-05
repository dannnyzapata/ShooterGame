using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float enemyHealth = 100f;
    public static int enemycounterdead = 0;
    EnemyAI enemyAI;
    public bool isEnemyDead = false;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void DeductHealth(float deductHealth)
    {
        if (!isEnemyDead)
        {
            enemyHealth -= deductHealth;

            if (enemyHealth <= 0) { EnemyDead(); }
        }
        
    }


    public void EnemyDead()
    {
        isEnemyDead = true;
        enemyAI.EnemyDeathAnim();
        Destroy(gameObject, 10);
        enemycounterdead++;
    }

   
}
