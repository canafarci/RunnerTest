using UnityEngine;

namespace Runner.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AIConfigSO", menuName = "SOs/AIConfigSO", order = 0)]
    public class AIConfigSO : ScriptableObject
    {
        public float AISpeed;
    }
}
