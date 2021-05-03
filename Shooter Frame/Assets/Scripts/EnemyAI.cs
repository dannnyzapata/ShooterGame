using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    bool isdead = false;
    public bool canattack = true;
    [SerializeField]
    float chasedistance = 2f;
    [SerializeField]
    float turnSpeed = 5f;
    public float damageAmount = 35f;
    [SerializeField]
    float attacktime = 2f;
    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position,target.position);

        if (distance > chasedistance && !isdead)
        {
            ChasePlayer();

        }
        else if (canattack && !PlayerHealth.singleton.IsDead) 
        {
            attackPlayer();
        }
        else if (PlayerHealth.singleton.IsDead)
        {
            Disableenemy();
        }

    }

    public void EnemyDeathAnim()
    {
        isdead = true;
        anim.SetTrigger("IsDead");
    }

    void ChasePlayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.SetDestination(target.position);
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsAttacking", false);
    }

    void attackPlayer()
    {
        agent.updateRotation = false;
        Vector3 direcccion = target.position - transform.position;
        direcccion.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direcccion), turnSpeed * Time.deltaTime);
        agent.updatePosition = false;
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsAttacking", true);
        StartCoroutine(AttackTime());
       
    }

    void Disableenemy()
    {
        canattack = false;
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsAttacking", false);
    }

    IEnumerator AttackTime()
    {
        canattack = false;
        yield return new WaitForSeconds(0.5f);
        PlayerHealth.singleton.DamagePlayer(damageAmount);
        yield return new WaitForSeconds(attacktime);
        canattack = true;

    }
}
