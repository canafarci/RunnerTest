using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Runner.StateMachine
{
    public class AIRestartState : RestartState
    {
        public AIRestartState(Transform transform, Rigidbody rigidbody) : base(transform, rigidbody)
        {
        }

        public override CharacterState Tick()
        {
            return CharacterState.AIWaitState;
        }
    }
}
