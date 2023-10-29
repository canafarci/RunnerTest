using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public abstract class CharacterStateMachine : IInitializable, IStateMachine, ITickable
    {
        protected Dictionary<CharacterState, IState> _stateLookup = new();
        protected IState _currentState;

        public void Initialize()
        {
            _currentState.Enter();
        }

        protected void ChangeState(CharacterState state)
        {
            if (_stateLookup.ContainsKey(state))
            {
                IState nextState = _stateLookup[state];
                TransitionTo(nextState);
            }
            else
            {
                throw new Exception($"{state} state is not found");
            }
        }

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


        protected void TransitionTo(IState nextState)
        {
            _currentState.Exit();
            _currentState = nextState;
            _currentState.Enter();
        }
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
