using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public abstract class CharacterStateMachine : MonoBehaviour
    {
        protected IState _currentState;
        protected IState _restartState;
        [SerializeField] private string _currentStateName;

        private void FixedUpdate()
        {
            CharacterState nextState = _currentState.Tick();

            //if tick function returns a pointer to the next state, then state has decided to exit
            if (nextState != CharacterState.StayInState)
            {
                ChangeState(nextState);
            }
        }

        public void ChangeStateToResetState()
        {
            TransitionTo(_restartState);
        }

        protected abstract void ChangeState(CharacterState nextState);

        protected void TransitionTo(IState nextState)
        {
            _currentState.Exit();
            _currentState = nextState;
            _currentState.Enter();
            _currentStateName = _currentState.ToString();
        }

    }

    public enum CharacterState
    {
        PlayerWaitForStartState,
        AIWaitState,
        PlayerMoveState,
        AIRandomMoveState,
        DecideState,
        PlayerRestartState,
        AIRestartState,
        AIMoveToFixedLocationState,
        AISyncWithObstacleState,
        AIMoveInRotatingPlatformState,
        AIMoveTowardsCenterState,
        StayInState
    }
}
