using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.StateMachine
{
    public abstract class RestartState : MonoBehaviour, IState
    {
        protected Vector3 _startPosition;
        private void Start()
        {
            _startPosition = transform.position;
        }
        public abstract void Enter();

        public abstract void Exit();

        public abstract CharacterState Tick();

    }
}
