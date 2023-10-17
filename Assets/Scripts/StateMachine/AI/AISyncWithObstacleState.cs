using System.Collections;
using System.Collections.Generic;
using Runner.Obstacles;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AISyncWithObstacleState : AIMoveState
    {
        private AIStateVariables _stateVariables;
        private bool _transitionToRandomMove = false;
        private ObstacleWaitPoint _waitPoint;
        public override void Enter()
        {
            _waitPoint = _stateVariables.CurrentObstacleData.GetWaitPoint();
            //if there is no avaliable wait positions, exit the current state
            if (_waitPoint == null)
            {
                _transitionToRandomMove = true;
                SetNextState(CharacterState.AIRandomMoveState);
            }
            else //a waitpoint is avaliable
            {
                _waitPoint.SetIsOccupied(true);
                SetNextState(CharacterState.AIMoveToFixedLocationState);
                SetTargetPosition(_waitPoint.transform.position);
            }
        }

        protected override bool CheckExitCondition(float distanceRemainingToSwitchState)
        {
            return _transitionToRandomMove || //exit state if there is no wait point
                    (base.CheckExitCondition(distanceRemainingToSwitchState) &&
                    _stateVariables.CurrentObstacleData.IsObstaclePassable());
        }
        public override void Exit()
        {
            _transitionToRandomMove = false;
            _waitPoint?.SetIsOccupied(false);
            _waitPoint = null;
        }

        [Inject]
        private void Init(AIStateVariables variables)
        {
            _stateVariables = variables;
        }

    }
}
