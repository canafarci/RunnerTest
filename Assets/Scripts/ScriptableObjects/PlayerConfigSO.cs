using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.ScriptableObjects
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "PlayerConfigSO", menuName = "SOs/PlayerConfigSO", order = 0)]
    public class PlayerConfigSO : ScriptableObject
    {
        public float PlayerSpeed;

        public float PlayerHeight;
    }
}