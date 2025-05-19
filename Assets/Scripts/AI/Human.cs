using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    private float moveSpeed = 3f;

    private NavMeshAgent agent;

    private void Start()
    {
        moveSpeed = Random.Range(1f, 3f);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }
    
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.SetDestination(GetRandomDestination());
        }
    }

    private Vector3 GetRandomDestination()
    {
        float range = 10f;
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, range, 1);
        return hit.position;
    }
}