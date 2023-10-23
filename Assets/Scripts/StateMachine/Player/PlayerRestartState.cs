using System.Collections;
using System.Collections.Generic;
using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class PlayerRestartState : RestartState
    {
        private PlayerRestartState(Transform transform, Rigidbody rigidbody) : base(transform)
        {
            _rigidbody = rigidbody;
        }

        public override CharacterState Tick()
        {
            return CharacterState.PlayerMoveState;
        }
    }
}
