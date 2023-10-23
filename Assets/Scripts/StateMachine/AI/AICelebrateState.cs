using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.StateMachine
{
    public class AICelebrateState : IState
    {
        public void Enter()
        {

        }

        public void Exit() { }

        public CharacterState Tick()
        {
            return CharacterState.StayInState;
        }

    }
}
