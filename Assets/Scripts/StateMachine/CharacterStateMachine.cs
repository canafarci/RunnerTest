using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public abstract class CharacterStateMachine : IInitializable, IStateMachine, ITickable
    {
        protected IState _currentState;
        protected IState _restartState;
        [SerializeField] private string _currentStateName;

        public void Tick()
        {
            CharacterState nextState = _currentState.Tick();

            //if tick function returns a pointer to the next state, then state has decided to exit
            if (nextState != CharacterState.StayInState)
            {
                ChangeState(nextState);
            }
        }

        public void AnyStateChange(CharacterState nextState)
        {
            ChangeState(nextState);
        }

        protected abstract void ChangeState(CharacterState nextState);

        protected void TransitionTo(IState nextState)
        {
            _currentState.Exit();
            _currentState = nextState;
            _currentState.Enter();
            _currentStateName = _currentState.ToString();
        }

        public abstract void Initialize();
    }

    public interface IStateMachine
    {
        public void AnyStateChange(CharacterState nextState);
    }

    public enum CharacterState
    {
        PlayerWaitForStartState,
        AIWaitState,
        PlayerMoveState,
        PlayerPaintState,
        AIRandomMoveState,
        DecideState,
        PlayerRestartState,
        AIRestartState,
        AIMoveToFixedLocationState,
        AISyncWithObstacleState,
        AIMoveInRotatingPlatformState,
        AIMoveTowardsCenterState,
        AIEndGameState,
        AICelebrateState,
        StayInState
    }
}
