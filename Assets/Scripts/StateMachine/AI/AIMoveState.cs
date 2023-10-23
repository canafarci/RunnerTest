using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public abstract class AIMoveState : IState
    {
        private Vector3 _targetPosition;
        private CharacterState _nextState;
        private IMoveable _aiMover;
        protected Transform _transform;
        private const float _distanceRemainingToSwitchState = 0.5f;

        public abstract void Enter();

        public abstract void Exit();

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState;

            Vector3 direction = GetDirection(_targetPosition);

            _aiMover.TickMovement(new Vector2(direction.x, direction.z));


            if (CheckExitCondition(_transform.position, _targetPosition, _distanceRemainingToSwitchState))
            {
                nextState = _nextState;
            }

            return nextState;
        }

        protected Vector3 GetDirection(Vector3 targetPosition)
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

        protected virtual bool CheckExitCondition(Vector3 currentPosition, Vector3 targetPosition, float distanceRemainingToSwitchState)
        {
            float distanceRemaining = Vector3.Distance(currentPosition, targetPosition);
            return distanceRemaining < distanceRemainingToSwitchState;
        }

        protected Vector3 GetRandomPositionInSphere(float radius)
        {
            Vector3 noise = radius * Random.insideUnitSphere;
            noise.y = 0f;
            return noise;
        }

        protected void SetNextState(CharacterState state) => _nextState = state;
        protected void SetTargetPosition(Vector3 pos) => _targetPosition = pos;

        //initialization
        protected AIMoveState(IMoveable mover, Transform transform)
        {
            _aiMover = mover;
            _transform = transform;
        }
    }
}
