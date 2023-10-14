using UnityEngine;
using Zenject;

namespace Runner.State
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected IState _currentState;

        private void Update()
        {
            IState nextState = _currentState.Tick();

            //if tick function returns a pointer to the next state, then state has decided to exit
            if (nextState != null)
            {
                ChangeState(nextState);
            }
        }

        protected void ChangeState(IState nextState)
        {
            _currentState.Exit();
            _currentState = nextState;
            _currentState.Enter();
        }
    }

    public enum BindingID
    {
        PlayerWaitForStartState,
        PlayerMoveState,
        DecideState
    }
}
