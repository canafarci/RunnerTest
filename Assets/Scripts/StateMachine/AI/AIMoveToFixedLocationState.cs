using System;
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
        private float _randomPositionRadius = 2f;

        public override void Enter()
        {
            CheckIfReachedEndGame();
            Vector3 destination = RandomizeDestinationPoint();
            SetTargetPosition(destination);
        }

        private void CheckIfReachedEndGame()
        {
            if (_stateVariables.HasAIReachedEndGame())
            {
                SetNextState(CharacterState.AICelebrateState);
                _randomPositionRadius = 0f;
            }
            else
            {
                SetNextState(CharacterState.DecideState);
            }
        }

        private Vector3 RandomizeDestinationPoint()
        {
            Vector3 destination = _stateVariables.GetTargetPosition();

            Vector3 noise = GetRandomPositionInSphere(_randomPositionRadius);
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
