using System.Linq;
using UnityEngine;

namespace Runner.Containers
{
    [System.Serializable]
    public class ObstacleData
    {
        [SerializeField] private ObstacleType _obstacleType;
        [SerializeField] private Transform _targetLocation;
        [SerializeField] private WaitPoint[] _waitLocations;
        [SerializeField] private bool _isPassable;

        public ObstacleType GetObstacleType() => _obstacleType;
        public Vector3 GetTargetPosition() => _targetLocation.position;
        public WaitPoint GetWaitPoint() => _waitLocations.Where(x => !x.IsOccupied()).FirstOrDefault();
        public bool IsObstaclePassable() => _isPassable;
        public void SetIsObstaclePassable(bool value) => _isPassable = value;
    }

    public enum ObstacleType
    {
        StaticObstacle,
        SyncableObstacle,
        RotatingObstacle
    }
}
