using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints
    public float moveSpeed = 2f; // Speed at which the enemy moves
    public float rotateSpeed = 5f; // Speed at which the enemy rotates
    public int waypointIndex = 0; // Current waypoint index

    private Transform targetPosition;


    private void Update()
    {
        if(waypointIndex < waypoints.Length)
        {
            targetPosition = waypoints[waypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);

            // Calculate the rotation towards the target
            Vector3 direction = (targetPosition.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Apply the rotation to your game object
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);


            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
            {
                if (waypointIndex < waypoints.Length - 1)
                {
                    waypointIndex++;
                }
                else
                    Destroy(gameObject);
            }
        }
    }
}
