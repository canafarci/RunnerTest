using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movement
{
    public class DirectionCalculator
    {
        private readonly Transform _transform;
        private const float _distanceRemainingToSwitchState = 0.5f;

        private DirectionCalculator(Transform transform)
        {
            _transform = transform;
        }
        public Vector3 GetDirection(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _transform.position;

            //filter small direction changes
            if (direction.magnitude < _distanceRemainingToSwitchState)
            {
                direction = Vector3.zero;
            }
            else
            {
                direction = direction.normalized;
            }

            return direction;
        }
    }
}
