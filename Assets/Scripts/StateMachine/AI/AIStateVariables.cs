using System.Collections;
using System.Collections.Generic;
using Runner.Obstacles;
using UnityEngine;

namespace Runner.StateMachine
{
    public class AIStateVariables : MonoBehaviour
    {
        private ObstacleData _obstacleData;
        public void SetObstacleData(ObstacleData data) => _obstacleData = data;
        public void ClearObstacleData() => _obstacleData = null;
        public Vector3 GetTargetPosition() => _obstacleData.GetTargetPosition();
        public ObstacleWaitPoint GetWaitPoint() => _obstacleData.GetWaitPoint();
        public bool IsCurrentObstaclePassable() => _obstacleData.IsObstaclePassable();
    }
}
