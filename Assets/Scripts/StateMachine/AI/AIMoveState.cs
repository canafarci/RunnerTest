using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AIMoveState : MonoBehaviour, IState
    {
        private Vector3 _targetPosition;
        private float _sampleRange = 3f;
        private IMoveable _aiMover;

        public void Enter()
        {
            _targetPosition = GetRandomPointInArc();
        }

        public void Exit()
        {

        }

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState;
            const float distanceRemainingToSwitchState = 0.15f;

            Vector3 direction = (_targetPosition - transform.position).normalized;
            _aiMover.TickMovement(new Vector2(direction.x, direction.z));

            if (Vector3.Distance(transform.position, _targetPosition) < distanceRemainingToSwitchState)
            {
                nextState = CharacterState.DecideState;
            }

            return nextState;
        }

        private Vector3 GetRandomPointInArc()
        {
            float angle = Random.Range(-45, 45); //90 degree arc witch center looking towards the end point
            float radian = angle * Mathf.Deg2Rad;
            Vector3 positionInArc = new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));

            return transform.position + positionInArc * _sampleRange;
        }

        //initialization
        [Inject]
        private void Init([Inject(Id = MovementComponents.AICharacterController)] IMoveable mover)
        {
            _aiMover = mover;
        }
    }
}
