using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{

    public Transform target;
    NavMeshAgent navMeshAgent;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float runningSpeed = 3.5f;

    ZombieHealth health;

    float distanceToTarget = Mathf.Infinity;

    bool isSpanning = true;
    bool isGettingShot = false;

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
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (!isSpanning && !isGettingShot)
        {

            FaceTarget();

            distanceToTarget = Vector3.Distance(target.position, transform.position);

            //Debug.Log("distance to target: " + distanceToTarget + ", otra cosa: " + navMeshAgent.stoppingDistance + .2);

            if (distanceToTarget <= 2.5)
            {
                AttackTarget();
            }
            else
            {
                ChaseTarget();
            }
        }
        
        
    }

    public void ZombieGettingShot()
    {
        isSpanning = false;
        isGettingShot = true;
        navMeshAgent.enabled = false;
        print("ahhhh si dolio");
    }

    public void ZombieGotShot()
    {
        isGettingShot = false;
        navMeshAgent.enabled = true;
        print("pos chido");

    }

    public void FinishedSpanning()
    {
        print("finished spannig");
        isSpanning = false;
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
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

    public void StartRunning()
    {
        navMeshAgent.speed = runningSpeed;
    }
}
