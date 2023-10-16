using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AIAvoidStaticObstacleState : AIMoveState
    {
        private AIStateVariables _stateVariables;

        public override void Enter()
        {
            _targetPosition = _stateVariables.AvoidObstacleDestination;
        }

        [Inject]
        private void Init(AIStateVariables variables)
        {
            _stateVariables = variables;
        }
    }
}
