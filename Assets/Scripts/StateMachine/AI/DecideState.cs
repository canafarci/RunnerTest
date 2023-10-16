using Runner.Sensors;
using Runner.Obstacles;
using Zenject;
using UnityEngine;

namespace Runner.StateMachine
{
    public class DecideState : MonoBehaviour, IState
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
                _stateVariables.CurrentObstacleData = data;

                if (data.GetObstacleType() == ObstacleType.StaticObstacle)
                {
                    _nextState = CharacterState.AIMoveToFixedLocationState;
                }
                else if (data.GetObstacleType() == ObstacleType.SyncableObstacle)
                {
                    _nextState = CharacterState.AISyncWithObstacleState;
                }
            }

            //move to fixed pos if it is static
            //async movement if dynamic
            //move sideways if turning obstacle
        }

        public void Exit()
        {
        }

        public CharacterState Tick()
        {
            return _nextState;
        }

        [Inject]
        private void Init(AIStateVariables variables, AISensor sensor)
        {
            _stateVariables = variables;
            _sensor = sensor;
        }
    }
}
