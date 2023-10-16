using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] protected ObstacleData _obstacleData;
        public ObstacleData GetObstacleData() => _obstacleData;
    }

    [System.Serializable]
    public class ObstacleData
    {
        [SerializeField] private ObstacleType _obstacleType;
        [SerializeField] private Transform _targetLocation;
        [SerializeField] private Transform _waitLocation;
        [SerializeField] private bool _isPassable;

        public ObstacleType GetObstacleType() => _obstacleType;
        public Vector3 GetTargetPosition() => _targetLocation.position;
        public Vector3 GetWaitPosition() => _waitLocation.position;
        public bool IsObstaclePassable() => _isPassable;
        public void SetIsObstaclePassable(bool value) => _isPassable = value;
    }

    public enum ObstacleType
    {
        StaticObstacle,
        SyncableObstacle
    }
}
