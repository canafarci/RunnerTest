using System.Collections;
using System.Collections.Generic;
using Runner.Movement;
using UnityEngine;

namespace Runner.StateMachine
{
    public class AIMoveTowardsCenterState : IState
    {
        private const float _maxTimeAllowedToReachCenter = 4f;
        private float _timeRemaining = _maxTimeAllowedToReachCenter;
        private Vector3 _targetPosition;
        private CharacterState _nextState;
        private readonly Transform _transform;
        private readonly IMoveable _aiMover;
        private readonly DirectionCalculator _directionCalculator;
        private readonly DistanceChecker _distanceChecker;

        private AIMoveTowardsCenterState(IMoveable mover,
                                         Transform transform,
                                         DirectionCalculator directionCalculator,
                                         DistanceChecker distanceChecker)
        {
            _transform = transform;
            _aiMover = mover;
            _directionCalculator = directionCalculator;
            _distanceChecker = distanceChecker;
        }
        public void Enter()
        {
            Vector3 target = GetCenterTarget();
            _targetPosition = target;
            _nextState = CharacterState.AIMoveInRotatingPlatformState;
        }

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState;

            Vector3 direction = _directionCalculator.GetDirection(_targetPosition);
            _aiMover.TickMovement(new Vector2(direction.x, direction.z));

            if (CheckExitCondition(_targetPosition, _transform.position))
            {
                nextState = _nextState;
            }

            return nextState;
        }

        private Vector3 GetCenterTarget()
        {
            Vector3 target = _transform.position;
            target.x = 0f;
            return target;
        }

        private bool CheckExitCondition(Vector3 targetPosition, Vector3 currentPosition)
        {
            bool canExitState = false;
            _timeRemaining -= Time.deltaTime;

            //if timer expires and havent reached the position, default to random movement
            if (_timeRemaining < 0f)
            {
                _nextState = CharacterState.AIRandomMoveState;
                canExitState = true;
            }
            //platform is curved, therefore y messes up distance calculation
            else
            {
                //platform is curved, therefore y messes up distance calculation
                ResetVectorY(ref currentPosition, ref targetPosition);
                canExitState = _distanceChecker.CheckIfReachedDestination(_transform.position);
            }

            return canExitState;
        }
        public void Exit()
        {
            _timeRemaining = _maxTimeAllowedToReachCenter;
        }

        private void ResetVectorY(ref Vector3 currentPosition, ref Vector3 targetPosition)
        {
            currentPosition.y = 0f;
            targetPosition.y = 0f;
        }


    }
}
