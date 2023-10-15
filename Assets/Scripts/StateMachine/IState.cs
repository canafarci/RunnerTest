using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.StateMachine
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public CharacterState Tick();
    }
}
