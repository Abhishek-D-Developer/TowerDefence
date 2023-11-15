using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "WaveScriptableObjectList", menuName = "ScriptableObjects/WaveList")]
    public class WaveScriptableObjectList : ScriptableObject
    {
        public EnemiesScriptableObjectList[] enemiesList;
    }
}