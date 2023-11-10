using System.Collections;
using System.Collections.Generic;
using Runner.Movement;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class PlayerRestartState : RestartState
    {
        public PlayerRestartState(Transform transform, Rigidbody rigidbody) : base(transform, rigidbody)
        {
        }

        public override CharacterState Tick()
        {
            return CharacterState.PlayerWaitState;
        }
    }
}
