using Zenject;

namespace Runner.StateMachine
{
    public class PlayerStateMachine : CharacterStateMachine
    {
        private IState _playerMoveState;
        private IState _playerPaintState;
        protected override void ChangeState(CharacterState nextState)
        {
            switch (nextState)
            {
                case CharacterState.PlayerMoveState:
                    TransitionTo(_playerMoveState);
                    break;
                case CharacterState.PlayerRestartState:
                    TransitionTo(_restartState);
                    break;
                case CharacterState.PlayerPaintState:
                    TransitionTo(_playerPaintState);
                    break;
            }
        }

        private void Start()
        {
            _currentState.Enter();
        }

        //initialization
        [Inject]
        private void Init([Inject(Id = CharacterState.PlayerWaitForStartState)] IState playerWaitState,
                          [Inject(Id = CharacterState.PlayerRestartState)] IState playerRestartState,
                          [Inject(Id = CharacterState.PlayerPaintState)] IState playerPaintState,
                          [Inject(Id = CharacterState.PlayerMoveState)] IState playerMoveState)
        {
            _currentState = playerWaitState;
            _playerMoveState = playerMoveState;
            _playerPaintState = playerPaintState;
            _restartState = playerRestartState;
        }
    }
}
