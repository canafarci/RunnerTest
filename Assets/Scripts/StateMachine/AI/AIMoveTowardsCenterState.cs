using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.StateMachine
{
    public class AIMoveTowardsCenterState : AIMoveState
    {
        private const float _maxTimeAllowedToReachCenter = 4f;
        private float _timeRemaining = _maxTimeAllowedToReachCenter;
        public override void Enter()
        {
            Vector3 target = GetCenterTarget();
            SetTargetPosition(target);
            SetNextState(CharacterState.AIMoveInRotatingPlatformState);
        }

        private Vector3 GetCenterTarget()
        {
            Vector3 target = transform.position;
            target.x = 0f;
            return target;
        }

        protected override bool CheckExitCondition(Vector3 currentPosition, Vector3 targetPosition, float distanceRemainingToSwitchState)
        {
            _timeRemaining -= Time.fixedDeltaTime; //state machine runs in fixeddeltatime

            //if timer expires and havent reached the position, default to random movement
            if (_timeRemaining < 0f)
            {
                SetNextState(CharacterState.AIRandomMoveState);
                return true;
            }
            //platform is curved, therefore y messes up distance calculation
            ResetVectorY(ref currentPosition, ref targetPosition);

            return base.CheckExitCondition(currentPosition, targetPosition, distanceRemainingToSwitchState);
        }
        public override void Exit()
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
