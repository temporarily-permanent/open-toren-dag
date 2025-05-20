using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float playerAura = 2f;
    [SerializeField] private float range = 10f;

    private NavMeshAgent agent;
    private GameObject player;

    private void Start()
    {
        moveSpeed = Random.Range(1f, 3f);
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            TryMoveToRandomDestination();
        }
    }

    private void TryMoveToRandomDestination()
    {
        var destination = GetRandomDestination();
        var distanceToPlayer = Vector3.Distance(destination, player.transform.position);
        if (distanceToPlayer > playerAura) // Avoid coming too close to the player
        {
            agent.SetDestination(destination);
        }
        else
        {
            Debug.Log("Avoiding player, distance: " + distanceToPlayer);
        }
    }

    private Vector3 GetRandomDestination()
    {
        var randomDirection = Random.insideUnitSphere * range;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, range, 1);
        return hit.position;
    }
}