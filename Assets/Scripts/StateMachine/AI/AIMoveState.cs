using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Runner.StateMachine
{
    public class AIMoveState : MonoBehaviour, IState
    {
        private NavMeshAgent _navMeshAgent;
        private readonly float _sampleRange = 3f;

        private Vector3 GetRandomDestination(float range)
        {
            Vector3 agentPosition = _navMeshAgent.transform.position;
            Vector3 randomPoint = agentPosition + Random.insideUnitSphere * range;

            if (randomPoint.z < agentPosition.z)
            {
                return GetRandomDestination(_sampleRange);
            }
            else
            {
                return GetDestination(randomPoint);
            }
        }

        private Vector3 GetDestination(Vector3 randomPoint)
        {
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                Vector3 result = hit.position;
                return result;
            }
            else
            {
                return GetRandomDestination(_sampleRange);
            }
        }

        public void Enter()
        {
            Vector3 destination = GetRandomDestination(_sampleRange);
            _navMeshAgent.SetDestination(destination);
        }

        public void Exit()
        {

        }

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState;
            const float distanceRemainingToSwitchState = 0.5f;

            if (_navMeshAgent.remainingDistance <= distanceRemainingToSwitchState)
            {
                nextState = CharacterState.DecideState;
            }

            return nextState;
        }

        //Initialization
        [Inject]
        private void Init(NavMeshAgent navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
        }
    }
}
