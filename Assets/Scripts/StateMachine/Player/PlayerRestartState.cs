using System.Collections;
using System.Collections.Generic;
using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class PlayerRestartState : RestartState
    {
        public override CharacterState Tick()
        {
            return CharacterState.PlayerMoveState;
        }

        //Initialization
        [Inject]
        private void Init([Inject(Id = MovementComponents.PlayerRigidbody)] Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }
    }
}
