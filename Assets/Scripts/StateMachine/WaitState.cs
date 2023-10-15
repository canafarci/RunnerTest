using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.StateMachine
{
    public abstract class WaitState : IState
    {
        protected float _timeLeft;
        protected CharacterState _nextState;
        public abstract void Enter();

        public void Exit() { }

        public virtual CharacterState Tick()
        {
            _timeLeft -= Time.deltaTime;

            CharacterState nextState = CharacterState.StayInState;

            if (_timeLeft < 0f)
            {
                nextState = OnTimerExpired();
            }
            return nextState;
        }

        protected virtual CharacterState OnTimerExpired()
        {
            return _nextState;
        }
    }
}
