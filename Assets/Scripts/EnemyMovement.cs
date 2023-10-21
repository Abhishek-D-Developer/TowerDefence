using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints
    public float moveSpeed = 5f; // Speed at which the enemy moves
    private int waypointIndex = 0; // Current waypoint index

    private void Start()
    {
        // Set the initial position to the first waypoint
        transform.position = waypoints[waypointIndex].position;
    }

    private void Update()
    {
        // Check if there are waypoints left to follow
        if (waypointIndex < waypoints.Length)
        {
            // Calculate the direction to the next waypoint
            Vector3 direction = waypoints[waypointIndex].position - transform.position;
            direction.Normalize();

            // Rotate the enemy towards the next waypoint
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }

            // Move the enemy towards the next waypoint
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // If the enemy is close to the current waypoint, switch to the next waypoint
            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.2f)
            {
                waypointIndex++;
            }
        }
        else
        {
            // The enemy has reached the end of the path, so you can destroy it or perform other actions.
            Destroy(gameObject);
        }
    }
}
