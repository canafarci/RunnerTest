using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Runner.StateMachine
{
    public class AIRestartState : RestartState
    {
        public override CharacterState Tick()
        {
            return CharacterState.DecideState;
        }

        //Initialization
        [Inject]
        private void Init(CharacterController characterController)
        {
            _characterController = characterController;
        }
    }
}
