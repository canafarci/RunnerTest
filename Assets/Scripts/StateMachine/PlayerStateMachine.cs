using UnityEngine;
using Zenject;

namespace Runner.State
{
    public class PlayerStateMachine : StateMachine
    {
        [Inject]
        private void Init([Inject(Id = BindingID.PlayerWaitForStartState)] IState currentState)
        {
            _currentState = currentState;
        }
        private void Start()
        {
            _currentState.Enter();
        }
    }
}
