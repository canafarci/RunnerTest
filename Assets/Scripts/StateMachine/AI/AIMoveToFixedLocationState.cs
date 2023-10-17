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
            Vector3 destination = _stateVariables.CurrentObstacleData.GetTargetPosition();
            Vector3 noise = 2f * Random.insideUnitSphere;
            noise.y = 0f;
            destination += noise;
            return destination;
        }

        public override void Exit()
        {
            _stateVariables.CurrentObstacleData = null;
        }

        [Inject]
        private void Init(AIStateVariables variables)
        {
            _stateVariables = variables;
        }
    }
}
