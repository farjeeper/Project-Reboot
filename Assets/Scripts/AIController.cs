using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float followSpeed = 5f; // Speed at which the AI bot follows the player
    public float stopDistance = 2f; // Distance at which the AI bot stops following the player

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Start()
    {
        // Get the NavMeshAgent component attached to the AI bot
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned in the AIController.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Calculate the distance between the AI bot and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stopDistance)
        {
            // Set the destination of the NavMeshAgent to the player's position
            navMeshAgent.SetDestination(player.position);
            navMeshAgent.speed = followSpeed;
        }
        else
        {
            // Stop the AI bot from moving when within the stop distance
            navMeshAgent.ResetPath();
        }
    }
}
