using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Runner.StateMachine
{
    public class AIRestartState : RestartState
    {
        private NavMeshAgent _navMeshAgent;

        public override void Enter()
        {
            ResetPosition();
        }

        public override CharacterState Tick()
        {
            return CharacterState.AIMoveState;
        }

        public override void Exit()
        {
            _navMeshAgent.isStopped = false;
        }

        private void ResetPosition()
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.ResetPath();
            _navMeshAgent.Warp(_startPosition);
        }

        //initialization
        [Inject]
        private void Init(NavMeshAgent navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
        }
    }
}
