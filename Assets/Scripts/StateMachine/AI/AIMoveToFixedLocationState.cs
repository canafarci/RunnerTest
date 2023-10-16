using System.Collections;
using System.Collections.Generic;
using Runner.Obstacles;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AIMoveToFixedLocationState : AIMoveState
    {
        private AIStateVariables _stateVariables;

        public override void Enter()
        {
            SetTargetPosition(_stateVariables.CurrentObstacleData.GetTargetPosition());
            SetNextState(CharacterState.DecideState);
        }

        [Inject]
        private void Init(AIStateVariables variables)
        {
            _stateVariables = variables;
        }
    }
}
