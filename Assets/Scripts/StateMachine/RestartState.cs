using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.StateMachine
{
    public abstract class RestartState : MonoBehaviour, IState
    {
        //dependencies
        protected Rigidbody _rigidbody;
        //state variables
        protected Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
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
            transform.position = _startPosition;
        }
    }
}
