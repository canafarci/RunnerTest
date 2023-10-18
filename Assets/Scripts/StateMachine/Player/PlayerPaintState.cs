using System;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class PlayerPaintState : MonoBehaviour, IState
    {
        public EventHandler OnPlayerEnteredPaintState;
        private Rigidbody _rigidbody;

        public void Enter()
        {
            OnPlayerEnteredPaintState?.Invoke(this, EventArgs.Empty);
            _rigidbody.isKinematic = true;
        }

        public void Exit()
        {

        }

        public CharacterState Tick()
        {
            return CharacterState.StayInState;
        }
        [Inject]
        private void Init(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

    }
}
