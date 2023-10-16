using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.StateMachine
{
    public class AIRandomMoveState : AIMoveState
    {
        private float _sampleRange = 1f;

        public override void Enter()
        {
            Vector3 targetPosition = GetRandomPointInArc();
            SetTargetPosition(targetPosition);
            SetNextState(CharacterState.DecideState);
        }

        private Vector3 GetRandomPointInArc()
        {
            float angle = Random.Range(-45, 45); //90 degree arc witch center looking towards the end point
            Vector3 positionInArc = ConvertAngleToPositionInArc(angle);

            return transform.position + positionInArc * _sampleRange;
        }

        private Vector3 ConvertAngleToPositionInArc(float angle)
        {
            float radian = angle * Mathf.Deg2Rad;
            Vector3 positionInArc = new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
            return positionInArc;
        }
    }
}
