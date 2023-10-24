using System.Collections;
using System.Collections.Generic;
using Runner.Movement;
using UnityEngine;

namespace Runner.StateMachine
{
    public class AIRandomMoveState : IState
    {
        private CharacterState _nextState;
        private Vector3 _targetPosition;
        private readonly IMoveable _aiMover;
        private readonly float _sampleRange = 2f;
        private readonly Transform _transform;
        private readonly DirectionCalculator _directionCalculator;
        private readonly DistanceChecker _distanceChecker;

        protected AIRandomMoveState(IMoveable mover,
                                    Transform transform,
                                    DirectionCalculator directionCalculator,
                                    DistanceChecker distanceChecker)
        {
            _aiMover = mover;
            _transform = transform;
            _directionCalculator = directionCalculator;
            _distanceChecker = distanceChecker;
        }

        public void Enter()
        {
            Vector3 targetPosition = GetRandomPointInArc();
            _targetPosition = targetPosition;
            _nextState = CharacterState.DecideState;
        }
        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState;

            Vector3 direction = _directionCalculator.GetDirection(_targetPosition);
            _aiMover.TickMovement(new Vector2(direction.x, direction.z));

            if (_distanceChecker.CheckIfReachedDestination(_targetPosition))
            {
                nextState = _nextState;
            }

            return nextState;
        }

        private Vector3 GetRandomPointInArc()
        {
            float angle = Random.Range(-25, 25); //50 degree arc witch center looking towards the end point
            Vector3 positionInArc = ConvertAngleToPositionInArc(angle);

            return _transform.position + positionInArc * _sampleRange;
        }

        private Vector3 ConvertAngleToPositionInArc(float angle)
        {
            float radian = angle * Mathf.Deg2Rad;
            Vector3 positionInArc = new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
            return positionInArc;
        }

        public void Exit() { }
    }
}
