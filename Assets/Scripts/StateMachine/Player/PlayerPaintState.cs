using System;
using Runner.Painting;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class PlayerPaintState : IState
    {
        public EventHandler OnPlayerEnteredPaintState;
        private Rigidbody _rigidbody;
        private Painter _painter;

        private PlayerPaintState(Rigidbody rigidbody, Painter painter)
        {
            _rigidbody = rigidbody;
            _painter = painter;
        }

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
            if (UnityEngine.Input.GetMouseButton(0))
            {
                _painter.TryPaint();
            }

            return CharacterState.StayInState;
        }
    }
}
