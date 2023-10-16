using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public abstract class AIMoveState : MonoBehaviour, IState
    {
        protected Vector3 _targetPosition;
        private IMoveable _aiMover;

        public abstract void Enter();

        public void Exit()
        {

        }

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState;

            Vector3 direction = (_targetPosition - transform.position).normalized;
            _aiMover.TickMovement(new Vector2(direction.x, direction.z));

            const float distanceRemainingToSwitchState = 0.15f;

            if (Vector3.Distance(transform.position, _targetPosition) < distanceRemainingToSwitchState)
            {
                nextState = CharacterState.DecideState;
            }

            return nextState;
        }

        //initialization
        [Inject]
        private void Init([Inject(Id = MovementComponents.AICharacterController)] IMoveable mover)
        {
            _aiMover = mover;
        }
    }
}
