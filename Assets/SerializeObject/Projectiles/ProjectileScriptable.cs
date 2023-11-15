using UnityEngine;

namespace ScriptableBullet
{
    [CreateAssetMenu(fileName = "ProjectileScriptableObject", menuName = "ScriptableObjects/NewProjectile")]
    public class ProjectileScriptableObject : ScriptableObject
    {
        public ProjectileType projectileType;
        public float speed;
        public float damage;
    }
}