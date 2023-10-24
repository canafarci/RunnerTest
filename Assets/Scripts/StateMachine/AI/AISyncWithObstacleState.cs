using Runner.Containers;
using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AISyncWithObstacleState : IState
    {
        private AIStateVariables _stateVariables;
        private bool _noWaitPointsAvaliable = false;
        private CharacterState _nextState;
        private WaitPoint _waitPoint;
        private Vector3 _targetPosition;
        private IMoveable _aiMover;
        private DirectionCalculator _directionCalculator;
        private DistanceChecker _distanceChecker;

        private AISyncWithObstacleState(IMoveable mover,
                                        DirectionCalculator directionCalculator,
                                        DistanceChecker distanceChecker,
                                        AIStateVariables stateVariables)
        {
            _aiMover = mover;
            _directionCalculator = directionCalculator;
            _distanceChecker = distanceChecker;
            _stateVariables = stateVariables;
        }

        public void Enter()
        {
            _waitPoint = _stateVariables.GetWaitPoint();
            //if there is no avaliable wait positions, exit the current state
            if (_waitPoint == null)
            {
                _noWaitPointsAvaliable = true;
                _nextState = CharacterState.AIRandomMoveState;
            }
            else //a waitpoint is avaliable
            {
                _nextState = CharacterState.AIMoveToFixedLocationState;
                _targetPosition = _waitPoint.transform.position;
            }
        }

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState;

            Vector3 direction = _directionCalculator.GetDirection(_targetPosition);
            _aiMover.TickMovement(new Vector2(direction.x, direction.z));

            if (CheckExitCondition(_targetPosition))
            {
                nextState = _nextState;
            }

            return nextState;
        }

        public void Exit()
        {
            _noWaitPointsAvaliable = false;
            _waitPoint?.SetIsOccupied(false);
            _waitPoint = null;
        }

        private bool CheckExitCondition(Vector3 targetPosition)
        {
            bool canExitState = false;

            if (_distanceChecker.CheckIfReachedDestination(targetPosition) &&
                    _stateVariables.IsCurrentObstaclePassable())
            {
                canExitState = true;
            }

            return canExitState || _noWaitPointsAvaliable;
        }
    }
}
