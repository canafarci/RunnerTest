using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movement
{
    public class DistanceChecker
    {
        private const float _distanceRemainingToSwitchState = 0.5f;
        private Transform _transform;

        private DistanceChecker(Transform transform)
        {
            _transform = transform;
        }

        public bool CheckIfReachedDestination(Vector3 targetPosition)
        {
            float distanceRemaining = Vector3.Distance(_transform.position, targetPosition);
            return distanceRemaining < _distanceRemainingToSwitchState;
        }
    }
}
