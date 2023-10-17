using System.Collections;
using System.Collections.Generic;
using Runner.Containers;
using Runner.Obstacles;
using UnityEngine;

namespace Runner.StateMachine
{
    public class AIStateVariables : MonoBehaviour
    {
        private ObstacleData _obstacleData;
        private Vector3 _targetPosition;
        private bool _hasReachedEndGame = false;
        public void SetObstacleData(ObstacleData data)
        {
            _obstacleData = data;
            Vector3 targetPosition = _obstacleData.GetTargetPosition();
            SetTargetPosition(targetPosition);
        }
        public void ClearObstacleData() => _obstacleData = null;
        public Vector3 GetTargetPosition() => _targetPosition;
        public WaitPoint GetWaitPoint() => _obstacleData.GetWaitPoint();
        public bool IsCurrentObstaclePassable() => _obstacleData.IsObstaclePassable();
        public void SetTargetPosition(Vector3 target) => _targetPosition = target;
        public void SetHasReachedEndGame() => _hasReachedEndGame = true;
        public bool HasAIReachedEndGame() => _hasReachedEndGame;
    }
}
