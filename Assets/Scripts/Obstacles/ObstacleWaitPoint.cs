using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Obstacles
{
    public class ObstacleWaitPoint : MonoBehaviour
    {
        private bool _isOccupied;

        public bool IsOccupied() => _isOccupied;
        public void SetIsOccupied(bool value) => _isOccupied = value;
    }
}
