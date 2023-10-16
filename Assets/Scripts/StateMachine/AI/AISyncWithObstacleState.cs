using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AISyncWithObstacleState : AIMoveState
    {
        private AIStateVariables _stateVariables;
        public override void Enter()
        {
            SetNextState(CharacterState.AIMoveToFixedLocationState);
            SetTargetPosition(_stateVariables.CurrentObstacleData.GetWaitPosition());
        }

        protected override bool CheckExitCondition(float distanceRemainingToSwitchState)
        {
            return base.CheckExitCondition(distanceRemainingToSwitchState)
                && _stateVariables.CurrentObstacleData.IsObstaclePassable();
        }

        [Inject]
        private void Init(AIStateVariables variables)
        {
            _stateVariables = variables;
        }
    }
}
