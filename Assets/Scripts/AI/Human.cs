using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Represents a human character that moves randomly within a specified range,
/// while avoiding coming too close to the player.
/// </summary>
public class Human : MonoBehaviour
{
    /// <summary>
    /// The movement speed of the human character.
    /// </summary>
    [SerializeField] private float moveSpeed = 3f;

    /// <summary>
    /// The minimum distance to maintain from the player.
    /// </summary>
    [SerializeField] private float playerAura = 2f;

    /// <summary>
    /// The range within which the human can move randomly.
    /// </summary>
    [SerializeField] private float range = 10f;

    private NavMeshAgent agent;
    private GameObject player;

    /// <summary>
    /// Initializes the human's movement speed and NavMeshAgent.
    /// Finds the player GameObject in the scene.
    /// </summary>
    private void Start()
    {
        moveSpeed = Random.Range(1f, 3f);
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    /// <summary>
    /// Updates the human's movement. If the human has reached its destination,
    /// it tries to move to a new random destination.
    /// </summary>
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            TryMoveToRandomDestination();
        }
    }

    /// <summary>
    /// Attempts to move the human to a random destination while avoiding the player.
    /// </summary>
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

    /// <summary>
    /// Generates a random destination within the specified range.
    /// Ensures the destination is on the NavMesh.
    /// </summary>
    /// <returns>The position of the random destination.</returns>
    private Vector3 GetRandomDestination()
    {
        var randomDirection = Random.insideUnitSphere * range;
        randomDirection += transform.position;
        NavMesh.SamplePosition(randomDirection, out var hit, range, 1);
        return hit.position;
    }
}