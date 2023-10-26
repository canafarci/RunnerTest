using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.Animation
{
    public class CharacterAnimationController : IFixedTickable
    {
        private Animator _animator;
        private Transform _transform;
        private Vector3 _lastPosition;
        private Vector3 _lastDirection;
        private readonly int _xMovementHash = Animator.StringToHash("XMovement");
        private readonly int _yMovementHash = Animator.StringToHash("YMovement");
        private readonly int _zMovementHash = Animator.StringToHash("ZMovement");
        private const float _interpolationFactor = 25f;


        private CharacterAnimationController(Animator animator, Transform transform)
        {
            _animator = animator;
            _transform = transform;
        }

        public void FixedTick()
        {
            Vector3 direction = GetDirection(_transform.position);

            _animator.SetFloat(_xMovementHash, direction.x);
            _animator.SetFloat(_yMovementHash, direction.y);
            _animator.SetFloat(_zMovementHash, direction.z);
        }

        private Vector3 GetDirection(Vector3 currentPosition)
        {
            Vector3 direction = currentPosition - _lastPosition;
            direction = direction.normalized;
            direction = Vector3.Lerp(direction, _lastDirection, Time.fixedDeltaTime * _interpolationFactor);

            _lastPosition = _transform.position;
            _lastDirection = direction;

            return direction;
        }
    }
}
