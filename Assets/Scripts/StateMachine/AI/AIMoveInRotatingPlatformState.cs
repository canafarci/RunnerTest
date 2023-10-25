using System.Collections;
using System.Collections.Generic;
using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AIMoveInRotatingPlatformState : IState
    {
        private CharacterState _nextState;
        private Vector3 _targetPosition;
        private float _timeRemaining = _maxTimeAllowedToReachCurrentDestination;
        private readonly AIStateVariables _stateVariables;
        private readonly PositionRandomizer _positionRandomizer;
        private const float _maxTimeAllowedToReachCurrentDestination = 4f;
        private const float _distanceLeftToExitState = 2f;
        private const float _transitionToMoveToCenterStateDistance = 4f;
        private readonly IMoveable _aiMover;
        private readonly Transform _transform;
        private readonly DirectionCalculator _directionCalculator;
        private readonly DistanceChecker _distanceChecker;

        private AIMoveInRotatingPlatformState(IMoveable mover,
                                                Transform transform,
                                                DirectionCalculator directionCalculator,
                                                DistanceChecker distanceChecker,
                                                AIStateVariables stateVariables,
                                                PositionRandomizer positionRandomizer)
        {
            _aiMover = mover;
            _transform = transform;
            _directionCalculator = directionCalculator;
            _distanceChecker = distanceChecker;
            _stateVariables = stateVariables;
            _positionRandomizer = positionRandomizer;
        }

        public void Enter()
        {
            Vector3 targetPosition = _stateVariables.GetTargetPosition();

            float distanceToDestination = Vector3.Distance(_transform.position, targetPosition);

            //divide path into smaller segment and re-enter this state after reaching destination
            if (distanceToDestination > _distanceLeftToExitState)
            {
                DividePath(targetPosition);
                _nextState = CharacterState.AIMoveInRotatingPlatformState;
            }
            else //move to target and exit state
            {
                _targetPosition = targetPosition;
                _nextState = CharacterState.DecideState;
            }
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

        private void DividePath(Vector3 targetPosition)
        {
            Vector3 direction = _directionCalculator.GetDirection(targetPosition);
            Vector3 target = _transform.position + direction * 2f;
            target = _positionRandomizer.RandomizeDestinationPoint(target, 1f);//randomize destination

            _targetPosition = target;
        }

        private bool CheckExitCondition(Vector3 targetPosition, Vector3 currentPosition)
        {
            bool canExitState = false;
            _timeRemaining -= Time.deltaTime;

            //if too much time is spent in this state, character is stuck, reenter state for new pos calculation
            if (_timeRemaining < 0f)
            {
                _nextState = CharacterState.AIMoveInRotatingPlatformState;
                canExitState = true;
            }

            else if (Mathf.Abs(_transform.position.x) > _transitionToMoveToCenterStateDistance) //character is off center
            {
                _nextState = CharacterState.AIMoveTowardsCenterState;
                canExitState = true;
            }
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
            _timeRemaining = _maxTimeAllowedToReachCurrentDestination;
        }

        private void ResetVectorY(ref Vector3 currentPosition, ref Vector3 targetPosition)
        {
            currentPosition.y = 0f;
            targetPosition.y = 0f;
        }
    }
}
