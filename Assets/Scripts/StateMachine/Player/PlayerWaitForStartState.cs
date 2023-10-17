using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class PlayerWaitForStartState : WaitState
    {
        private PlayerWaitForStartState()
        {
            _nextState = CharacterState.PlayerMoveState;
        }
        public override void Enter()
        {
            _timeLeft = 0f;
        }
    }
}
