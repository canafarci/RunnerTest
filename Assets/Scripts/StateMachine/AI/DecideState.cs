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
                if (data.ObstacleType == ObstacleType.StaticObstacle)
                {
                    _stateVariables.AvoidObstacleDestination = data.MoveDestination.position;
                    _nextState = CharacterState.AIAvoidStaticObstacleState;
                }
            }

            //move to fixed pos if it is static
            //async movement if dynamic
            //move sideways if turning obstacle
        }

        public void Exit()
        {
            //throw new System.NotImplementedException();
        }

        public CharacterState Tick()
        {
            UnityEngine.Debug.Log("Decided");
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
