using System.Collections;
using System.Collections.Generic;
using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AIMoveInRotatingPlatformState : AIMoveState
    {
        private AIStateVariables _stateVariables;
        private const float _maxTimeAllowedToReachCurrentDestination = 4f;
        private const float _distanceLeftToExitState = 2f;
        private const float _transitionToMoveToCenterStateDistance = 4f;
        private float _timeRemaining = _maxTimeAllowedToReachCurrentDestination;

        protected AIMoveInRotatingPlatformState(IMoveable mover,
                                          Transform transform,
                                          AIStateVariables stateVariables) : base(mover, transform)
        {
            _stateVariables = stateVariables;
        }

        public override void Enter()
        {
            Vector3 targetPosition = _stateVariables.GetTargetPosition();

            float distanceToDestination = Vector3.Distance(_transform.position, targetPosition);

            //divide path into smaller segment and re-enter this state after reaching destination
            if (distanceToDestination > _distanceLeftToExitState)
            {
                DividePath(targetPosition);
                SetNextState(CharacterState.AIMoveInRotatingPlatformState);
            }
            else //move to target and exit state
            {
                SetTargetPosition(targetPosition);
                SetNextState(CharacterState.DecideState);
            }
        }

        private void DividePath(Vector3 targetPosition)
        {
            Vector3 direction = GetDirection(targetPosition);
            Vector3 target = _transform.position + direction * 2f;
            target += GetRandomPositionInSphere(1f); //randomize destination

            SetTargetPosition(target);
        }

        protected override bool CheckExitCondition(Vector3 currentPosition,
                                                   Vector3 targetPosition,
                                                   float distanceRemainingToSwitchState)
        {
            _timeRemaining -= Time.fixedDeltaTime; //state machine runs in fixeddeltatime

            //if too much time is spent in this state, character is stuck, reenter state for new pos calculation
            if (_timeRemaining < 0f)
            {
                SetNextState(CharacterState.AIMoveInRotatingPlatformState);
                return true;
            }
            else if (Mathf.Abs(_transform.position.x) > _transitionToMoveToCenterStateDistance) //character is off center
            {
                SetNextState(CharacterState.AIMoveTowardsCenterState);
                return true;
            }

            //platform is curved, therefore y messes up distance calculation
            ResetVectorY(ref currentPosition, ref targetPosition);

            Debug.DrawLine(currentPosition, targetPosition, Color.red, 0.5f);

            return base.CheckExitCondition(currentPosition, targetPosition, distanceRemainingToSwitchState);
        }
        public override void Exit()
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
