using Runner.Sensors;
using Zenject;
using UnityEngine;
using Runner.Containers;

namespace Runner.StateMachine
{
    public class DecideState : IState
    {
        private AISensor _sensor;
        private AIStateVariables _stateVariables;
        private CharacterState _nextState;
        public void Enter()
        {
            //sensor.get
            ObstacleData data = _sensor.CheckObstacles();
            //switch on returned obstacletype
            if (data == null)
            {
                _nextState = CharacterState.AIRandomMoveState;
            }
            else
            {
                //all obstacles have a valid pass destination
                _stateVariables.SetObstacleData(data);

                if (data.GetObstacleType() == ObstacleType.StaticObstacle)
                {
                    _nextState = CharacterState.AIMoveToFixedLocationState;
                }
                else if (data.GetObstacleType() == ObstacleType.SyncableObstacle)
                {
                    _nextState = CharacterState.AISyncWithObstacleState;
                }
                else if (data.GetObstacleType() == ObstacleType.RotatingObstacle)
                {
                    _nextState = CharacterState.AIMoveInRotatingPlatformState;
                }
            }
        }

        public void Exit()
        {
        }

        public CharacterState Tick()
        {
            return _nextState;
        }

        private DecideState(AIStateVariables variables, AISensor sensor)
        {
            _stateVariables = variables;
            _sensor = sensor;
        }
    }
}
