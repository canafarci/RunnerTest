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
            Vector3 destination = RandomizeDestinationPoint();
            SetTargetPosition(destination);
            SetNextState(CharacterState.DecideState);
        }

        private Vector3 RandomizeDestinationPoint()
        {
            Vector3 destination = _stateVariables.GetTargetPosition();

            Vector3 noise = GetRandomPositionInSphere(2f);
            destination += noise;
            return destination;
        }

        public override void Exit()
        {
            _stateVariables.ClearObstacleData();
        }

        [Inject]
        private void Init(AIStateVariables variables)
        {
            _stateVariables = variables;
        }
    }
}
