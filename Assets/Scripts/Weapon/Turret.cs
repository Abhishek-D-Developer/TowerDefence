using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 10f; // Range within which the turret can detect enemies
    public float fireRate = 1f; // Rate of fire (shots per second)
    public Transform rotatingPart; // The part of the turret that rotates to aim at the target
    public Transform firePoint; // The point from which the turret shoots
    public GameObject bulletPrefab; // Prefab of the bullet or projectile to be fired

    private float fireCountdown = 0f; // Countdown until the turret can fire again
    private Transform target; // Current target (enemy)

    private void Update()
    {
        // Look for the nearest enemy in the range
        FindNearestTarget();

        // If there's a target and the countdown allows firing, shoot at the target
        if (target != null)
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void FindNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Replace "Enemy" with the tag you use for enemies

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            RotateTurret();
        }
        else
        {
            target = null;
        }
    }

    void RotateTurret()
    {
        Vector3 direction = target.position - rotatingPart.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * 5f).eulerAngles;
        rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        // Instantiate a bullet or projectile and set its position and direction
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            //bulletScript.Seek(target);
        }
    }
}
