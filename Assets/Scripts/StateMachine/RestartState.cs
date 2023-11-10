using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public abstract class RestartState : IState, IRestartable
    {
        //dependencies
        protected Rigidbody _rigidbody;
        //state variables
        protected Vector3 _startPosition = Vector3.zero;
        private readonly Transform _transform;
        private const int RESTART_DELAY = 2100;

        public event EventHandler OnCharacterRestart;

        protected RestartState(Transform transform, Rigidbody rigidbody)
        {
            _transform = transform;
            _rigidbody = rigidbody;
        }

        public void Enter()
        {
            Restart();
            _rigidbody.isKinematic = true;
        }

        private async void Restart()
        {
            OnCharacterRestart?.Invoke(this, EventArgs.Empty);
            await Task.Delay(RESTART_DELAY);

            ResetPosition();
        }

        public abstract CharacterState Tick();

        public void Exit()
        {

        }

        private void ResetPosition()
        {
            if (_transform != null)
            {
                _transform.localPosition = _startPosition;
                _rigidbody.isKinematic = false;
            }
        }
    }

    public interface IRestartable
    {
        public event EventHandler OnCharacterRestart;
    }
}
