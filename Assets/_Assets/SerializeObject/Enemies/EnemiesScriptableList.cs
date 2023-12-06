using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "EnemiesScriptableObjectList", menuName = "ScriptableObjects/NewEnemyList")]
    public class EnemiesScriptableObjectList : ScriptableObject
    {
        public EnemiesScriptableObject[] enemiesList;
    }
}