using System;
using Zenject;

namespace Runner.StateMachine
{
    public class AIStateMachine : CharacterStateMachine
    {
        private AIStateMachine([Inject(Id = CharacterState.AIRestartState)] IState restartState,
                               [Inject(Id = CharacterState.AIWaitState)] IState waitState,
                               [Inject(Id = CharacterState.AIMoveToFixedLocationState)] IState moveToFixedLocationState,
                               [Inject(Id = CharacterState.AISyncWithObstacleState)] IState syncWithObstacleState,
                               [Inject(Id = CharacterState.AIMoveInRotatingPlatformState)] IState moveInRotatingPlatformState,
                               [Inject(Id = CharacterState.AIMoveTowardsCenterState)] IState moveTowardsCenterState,
                               [Inject(Id = CharacterState.DecideState)] IState decideState,
                               [Inject(Id = CharacterState.AIEndGameState)] IState endGameState,
                               [Inject(Id = CharacterState.AICelebrateState)] IState celebrateState,
                               [Inject(Id = CharacterState.AIRandomMoveState)] IState moveState)
        {
            _stateLookup[CharacterState.AIRestartState] = restartState;
            _stateLookup[CharacterState.AIWaitState] = waitState;
            _stateLookup[CharacterState.AIMoveToFixedLocationState] = moveToFixedLocationState;
            _stateLookup[CharacterState.AISyncWithObstacleState] = syncWithObstacleState;
            _stateLookup[CharacterState.AIMoveInRotatingPlatformState] = moveInRotatingPlatformState;
            _stateLookup[CharacterState.AIMoveTowardsCenterState] = moveTowardsCenterState;
            _stateLookup[CharacterState.DecideState] = decideState;
            _stateLookup[CharacterState.AIEndGameState] = endGameState;
            _stateLookup[CharacterState.AICelebrateState] = celebrateState;
            _stateLookup[CharacterState.AIRandomMoveState] = moveState;

            _currentState = waitState;
        }
    }
}
