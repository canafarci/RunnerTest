using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public abstract class AIMoveState : MonoBehaviour, IState
    {
        private Vector3 _targetPosition;
        private CharacterState _nextState;
        private IMoveable _aiMover;
        private const float _distanceRemainingToSwitchState = 0.15f;

        public abstract void Enter();

        public abstract void Exit();

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState;

            Vector3 direction = GetDirection();

            _aiMover.TickMovement(new Vector2(direction.x, direction.z));


            if (CheckExitCondition(_distanceRemainingToSwitchState))
            {
                nextState = _nextState;
            }

            return nextState;
        }

        private Vector3 GetDirection()
        {
            Vector3 direction = _targetPosition - transform.position;

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

        protected virtual bool CheckExitCondition(float distanceRemainingToSwitchState)
        {
            return Vector3.Distance(transform.position, _targetPosition) < distanceRemainingToSwitchState;
        }

        protected void SetNextState(CharacterState state) => _nextState = state;
        protected void SetTargetPosition(Vector3 pos) => _targetPosition = pos;

        //initialization
        [Inject]
        private void Init([Inject(Id = MovementComponents.AICharacterController)] IMoveable mover)
        {
            _aiMover = mover;
        }
    }
}
