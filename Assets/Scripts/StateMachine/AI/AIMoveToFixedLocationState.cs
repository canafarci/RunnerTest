using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Movement;
using Runner.Obstacles;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AIMoveToFixedLocationState : IState
    {
        private CharacterState _nextState;
        private Vector3 _targetPosition;
        private float _randomPositionRadius = 2f;
        private readonly AIStateVariables _stateVariables;
        private readonly PositionRandomizer _positionRandomizer;
        private readonly IMoveable _aiMover;
        private readonly DirectionCalculator _directionCalculator;
        private readonly DistanceChecker _distanceChecker;

        private AIMoveToFixedLocationState(IMoveable mover,
                                            DirectionCalculator directionCalculator,
                                            DistanceChecker distanceChecker,
                                            AIStateVariables stateVariables,
                                            PositionRandomizer positionRandomizer)
        {
            _aiMover = mover;
            _directionCalculator = directionCalculator;
            _distanceChecker = distanceChecker;
            _stateVariables = stateVariables;
            _positionRandomizer = positionRandomizer;
        }

        public void Enter()
        {
            CheckIfReachedEndGame();

            Vector3 destination = _stateVariables.GetTargetPosition();
            Vector3 targetPosition = _positionRandomizer.RandomizeDestinationPoint(destination, _randomPositionRadius);
            _targetPosition = targetPosition;
        }

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState;

            Vector3 direction = _directionCalculator.GetDirection(_targetPosition);
            _aiMover.TickMovement(new Vector2(direction.x, direction.z));

            if (_distanceChecker.CheckIfReachedDestination(_targetPosition))
            {
                nextState = _nextState;
            }

            return nextState;
        }

        private void CheckIfReachedEndGame()
        {
            if (_stateVariables.HasAIReachedEndGame())
            {
                _nextState = CharacterState.AICelebrateState;
                _randomPositionRadius = 0f;
            }
            else
            {
                _nextState = CharacterState.DecideState;
            }
        }
        public void Exit()
        {
            _stateVariables.ClearObstacleData();
        }
    }
}
