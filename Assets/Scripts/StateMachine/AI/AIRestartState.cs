using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Runner.StateMachine
{
    public class AIRestartState : RestartState
    {
        protected AIRestartState(Rigidbody rigidbody, Transform transform) : base(transform)
        {
            _rigidbody = rigidbody;
        }

        public override CharacterState Tick()
        {
            return CharacterState.DecideState;
        }
    }
}
