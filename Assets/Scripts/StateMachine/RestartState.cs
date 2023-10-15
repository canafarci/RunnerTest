using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.StateMachine
{
    public abstract class RestartState : MonoBehaviour, IState
    {
        //dependencies
        protected CharacterController _characterController;
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
            _characterController.enabled = true;
        }

        private void ResetPosition()
        {
            _characterController.enabled = false;
            transform.position = _startPosition;
        }
    }
}
