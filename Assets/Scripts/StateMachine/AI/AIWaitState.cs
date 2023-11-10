using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AIWaitState : WaitState
    {
        private AIWaitState()
        {
            _nextState = CharacterState.DecideState;
        }
    }
}
