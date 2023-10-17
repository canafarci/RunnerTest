using Zenject;

namespace Runner.StateMachine
{
    public class AIStateMachine : CharacterStateMachine
    {
        private IState _waitState;
        private IState _decideState;
        private IState _moveState;
        private IState _moveToFixedLocationState;
        private IState _syncWithObstacleState;
        private IState _moveInRotatingPlatformState;
        private IState _moveTowardsCenterState;

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
                case CharacterState.AIMoveToFixedLocationState:
                    TransitionTo(_moveToFixedLocationState);
                    break;
                case CharacterState.AISyncWithObstacleState:
                    TransitionTo(_syncWithObstacleState);
                    break;
                case CharacterState.AIMoveInRotatingPlatformState:
                    TransitionTo(_moveInRotatingPlatformState);
                    break;
                case CharacterState.AIMoveTowardsCenterState:
                    TransitionTo(_moveTowardsCenterState);
                    break;
                default:
                    break;
            }
        }

        [Inject]
        private void Init([Inject(Id = CharacterState.AIRestartState)] IState restartState,
                          [Inject(Id = CharacterState.AIMoveToFixedLocationState)] IState moveToFixedLocationState,
                          [Inject(Id = CharacterState.AISyncWithObstacleState)] IState syncWithObstacleState,
                          [Inject(Id = CharacterState.AIMoveInRotatingPlatformState)] IState moveInRotatingPlatformState,
                          [Inject(Id = CharacterState.AIMoveTowardsCenterState)] IState moveTowardsCenterState,
                          [Inject(Id = CharacterState.AIWaitState)] IState waitState,
                          [Inject(Id = CharacterState.DecideState)] IState decideState,
                          [Inject(Id = CharacterState.AIRandomMoveState)] IState moveState)
        {
            _waitState = waitState;
            _restartState = restartState;
            _moveToFixedLocationState = moveToFixedLocationState;
            _syncWithObstacleState = syncWithObstacleState;
            _moveInRotatingPlatformState = moveInRotatingPlatformState;
            _moveTowardsCenterState = moveTowardsCenterState;
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
