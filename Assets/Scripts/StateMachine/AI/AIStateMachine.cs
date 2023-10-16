using Zenject;

namespace Runner.StateMachine
{
    public class AIStateMachine : CharacterStateMachine
    {
        private IState _waitState;
        private IState _decideState;
        private IState _moveState;
        private IState _avoidStaticObstacleState;

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
                case CharacterState.AIRandomMoveState:
                    TransitionTo(_moveState);
                    break;
                case CharacterState.AIAvoidStaticObstacleState:
                    TransitionTo(_avoidStaticObstacleState);
                    break;
                default:
                    break;
            }
        }

        [Inject]
        private void Init([Inject(Id = CharacterState.AIRestartState)] IState restartState,
                          [Inject(Id = CharacterState.AIAvoidStaticObstacleState)] IState avoidStaticObstacleState,
                          [Inject(Id = CharacterState.AIWaitState)] IState waitState,
                          [Inject(Id = CharacterState.DecideState)] IState decideState,
                          [Inject(Id = CharacterState.AIRandomMoveState)] IState moveState)
        {
            _waitState = waitState;
            _restartState = restartState;
            _avoidStaticObstacleState = avoidStaticObstacleState;
            _decideState = decideState;
            _moveState = moveState;

            _currentState = _waitState;
        }

        private void Start()
        {
            _currentState.Enter();
        }
    }
}
