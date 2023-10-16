using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private ObstacleData _obstacleData;
        public ObstacleData GetObstacleData() => _obstacleData;
    }

    [System.Serializable]
    public class ObstacleData
    {
        public ObstacleType ObstacleType;
        public Transform MoveDestination;
    }

    public enum ObstacleType
    {
        StaticObstacle
    }
}
