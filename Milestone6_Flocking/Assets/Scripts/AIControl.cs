using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AiControl : MonoBehaviour
{
    GameObject[] goalLocations;

    NavMeshAgent agent;

    Animator animator;

    float speedMult;

    float detectionRadius = 10;

    float fleeRadius = 10;

    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        animator.SetFloat("wOffset", Random.Range(0, 1));
        ResetAgent();
        
    }

    void Update()
    {
        if(agent.remainingDistance < 2)
        {
            ResetAgent();
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }

    void ResetAgent()
    {
        speedMult = Random.Range(0.1f, 1.5f);
        agent.speed= speedMult;
        agent.angularSpeed = 120;
        animator.SetFloat("speedMultiplier", speedMult);
        animator.SetTrigger("isWalking");
        agent.ResetPath();
    }

    public void DetectFleeObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - location).normalized;
            Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);
            
            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                animator.SetTrigger("isRunning");
                agent.speed = 10;
                agent.angularSpeed = 500;
            }
        }
    }

    public void DetectFlockObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            Vector3 flockDirection = location - this.transform.position;
            Vector3 newGoal = this.transform.position + flockDirection;

                agent.SetDestination(newGoal);
                animator.SetTrigger("isRunning");
                agent.speed = 10;
                agent.angularSpeed = 250;
            
        }
    }

}
