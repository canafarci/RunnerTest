using Zenject;

namespace Runner.StateMachine
{
    public class PlayerStateMachine : CharacterStateMachine
    {
        private PlayerStateMachine([Inject(Id = CharacterState.PlayerWaitState)] IState playerWaitState,
                                   [Inject(Id = CharacterState.PlayerRestartState)] IState playerRestartState,
                                   [Inject(Id = CharacterState.PlayerPaintState)] IState playerPaintState,
                                   [Inject(Id = CharacterState.PlayerMoveState)] IState playerMoveState)
        {
            _currentState = playerWaitState;

            _stateLookup[CharacterState.PlayerWaitState] = playerWaitState;
            _stateLookup[CharacterState.PlayerMoveState] = playerMoveState;
            _stateLookup[CharacterState.PlayerPaintState] = playerPaintState;
            _stateLookup[CharacterState.PlayerRestartState] = playerRestartState;
        }
    }
}
