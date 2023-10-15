using Zenject;

namespace Runner.StateMachine
{
    public class AIStateMachine : CharacterStateMachine
    {
        private IState _waitState;
        private IState _decideState;
        private IState _moveState;

        [Inject]
        private void Init([Inject(Id = CharacterState.AIWaitState)] IState waitState,
                                [Inject(Id = CharacterState.DecideState)] IState decideState,
                                [Inject(Id = CharacterState.AIMoveState)] IState moveState)
        {
            _waitState = waitState;
            _decideState = decideState;
            _moveState = moveState;
        }

        protected override void ChangeState(CharacterState nextState)
        {
            switch (nextState)
            {
                case CharacterState.AIWaitState:
                    TransitionTo(_waitState);
                    break;
                case CharacterState.DecideState:
                    TransitionTo(_decideState);
                    break;
                case CharacterState.AIMoveState:
                    TransitionTo(_moveState);
                    break;
                default:
                    break;
            }
        }

        [Inject]
        private void Init([Inject(Id = CharacterState.AIWaitState)] IState currentState,
                          [Inject(Id = CharacterState.AIRestartState)] IState aiRestartState)
        {
            _currentState = currentState;
            _restartState = aiRestartState;
        }

        private void Start()
        {
            _currentState.Enter();
        }
    }
}
