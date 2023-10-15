using Zenject;

namespace Runner.StateMachine
{
    public class PlayerStateMachine : StateMachine
    {
        private IState _playerMoveState;
        protected override void ChangeState(CharacterState nextState)
        {
            if (nextState == CharacterState.PlayerMoveState)
            {
                TransitionTo(_playerMoveState);
            }
        }

        private void Start()
        {
            _currentState.Enter();
        }

        //initialization
        [Inject]
        private void Init([Inject(Id = CharacterState.PlayerWaitForStartState)] IState playerWaitState,
                          [Inject(Id = CharacterState.PlayerMoveState)] IState playerMoveState)
        {
            _currentState = playerWaitState;
            _playerMoveState = playerMoveState;
        }
    }
}
