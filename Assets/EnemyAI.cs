using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    [SerializeField] float turnSpeed = 5f;

    ZombieHealth health;

    float distanceToTarget = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<ZombieHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            enabled = false; //disables AI
            navMeshAgent.enabled = false; //disables nav mesh agent
        }

        FaceTarget();

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= navMeshAgent.stoppingDistance+.2)
        {
            AttackTarget();
        }
        else
        {
            ChaseTarget();

        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        // transform.rotation = where the target is, we need to rotate at a certain speed
    }
}
