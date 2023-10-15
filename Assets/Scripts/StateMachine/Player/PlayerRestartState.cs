using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class PlayerRestartState : RestartState
    {
        private CharacterController _characterController;

        public override void Enter()
        {
            ResetPosition();
        }

        public override CharacterState Tick()
        {
            return CharacterState.PlayerMoveState;
        }

        public override void Exit()
        {
            _characterController.enabled = true;
        }

        private void ResetPosition()
        {
            _characterController.enabled = false;
            transform.position = _startPosition;
        }

        //Initialization
        [Inject]
        private void Init(CharacterController characterController)
        {
            _characterController = characterController;
        }
    }
}
