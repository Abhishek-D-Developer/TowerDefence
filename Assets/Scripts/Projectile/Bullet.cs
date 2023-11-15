using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    public float lifetime = 2f;

    private Transform target;

    private void Update()
    {
        // Move the bullet towards the target
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void HitTarget()
    {
        // Apply damage to the target (you can customize this part)
        // For example, you might have a script on your enemy object to handle damage.
        // target.GetComponent<Enemy>().TakeDamage(damage);

        ReturnToPool();
    }

    void ReturnToPool()
    {
        target = null;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        // When the bullet is enabled, start a countdown to return it to the pool
        Invoke("ReturnToPool", lifetime);
    }
}
