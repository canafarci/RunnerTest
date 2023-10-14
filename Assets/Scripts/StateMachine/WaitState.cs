using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.State
{
    public abstract class WaitState : MonoBehaviour, IState
    {
        protected float _waitDuration;
        private float _timeLeft;
        protected IState _nextState;
        public virtual void Enter()
        {
            _timeLeft = _waitDuration;
        }

        public void Exit() { }

        public IState Tick()
        {
            _timeLeft -= Time.deltaTime;

            IState nextState = null;

            if (_timeLeft < 0f)
            {
                nextState = _nextState;

            }
            return nextState;
        }
    }
}
