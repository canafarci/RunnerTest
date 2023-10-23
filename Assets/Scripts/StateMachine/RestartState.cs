using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public abstract class RestartState : IState
    {
        //dependencies
        protected Rigidbody _rigidbody;
        //state variables
        protected Vector3 _startPosition = Vector3.zero;
        private readonly Transform _transform;

        protected RestartState(Transform transform)
        {
            _transform = transform;
        }

        public void Enter()
        {
            ResetPosition();
        }

        public abstract CharacterState Tick();

        public void Exit()
        {
            _rigidbody.isKinematic = false;
        }

        private void ResetPosition()
        {
            _rigidbody.isKinematic = true;
            _transform.localPosition = _startPosition;
        }
    }
}
