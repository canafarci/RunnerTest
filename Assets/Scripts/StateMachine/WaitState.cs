using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.StateMachine
{
    public abstract class WaitState : IState
    {
        private int _timesWaitedBefore = 0;
        private const float RESTART_DELAY = 2.1f;
        private const float START_WAIT_DURATION = 3f;
        protected float _timeLeft;
        protected CharacterState _nextState;

        public void Enter()
        {
            SetWaitDuration();
        }

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

        private void SetWaitDuration()
        {
            if (_timesWaitedBefore == 0)
            {
                _timeLeft = START_WAIT_DURATION;
            }
            else
            {
                _timeLeft = RESTART_DELAY;
            }

            _timesWaitedBefore++;
        }

        protected virtual CharacterState OnTimerExpired()
        {
            return _nextState;
        }
    }
}
