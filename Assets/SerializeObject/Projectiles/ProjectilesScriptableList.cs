using ScriptableBullet;
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "ProjectileScriptableObjectList", menuName = "ScriptableObjects/NewProjectileList")]
    public class ProjectileScriptableObjectList : ScriptableObject
    {
        public ProjectileScriptableObject[] bullet;
    }
}
