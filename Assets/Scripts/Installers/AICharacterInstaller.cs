using System.Collections;
using System.Collections.Generic;
using Runner.Containers;
using Runner.Creation;
using Runner.Movement;
using Runner.Sensors;
using Runner.StateMachine;
using UnityEngine;
using Zenject;

public class AICharacterInstaller : Installer<AICharacterInstaller>
{
    private EndGameWaitPoints _endGameWaitPoints;
    private AICharacterInstaller(EndGameWaitPoints endGameWaitPoints)
    {
        _endGameWaitPoints = endGameWaitPoints;
    }
    public override void InstallBindings()
    {
        Container.Bind<AICharacter>().AsSingle();
        Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
        Container.Bind<Rigidbody>().FromComponentOnRoot().AsSingle();

        Container.Bind<DistanceChecker>().AsSingle();
        Container.Bind<DirectionCalculator>().AsSingle();


        Container.BindInterfacesAndSelfTo<AIStateMachine>().AsSingle();
        Container.BindInterfacesAndSelfTo<AISensor>().AsSingle();
        Container.Bind<AIStateVariables>().AsSingle();

        Container.Bind<IMoveable>()
                     .To<AIMover>()
                     .AsSingle();

        Container.Bind<IState>()
                 .WithId(CharacterState.AIWaitState)
                 .To<AIWaitState>()
                 .AsSingle();

        Container.Bind<IState>()
                 .WithId(CharacterState.AIRandomMoveState)
                 .To<AIRandomMoveState>()
                 .AsSingle();

        Container.Bind<IState>()
                 .WithId(CharacterState.AIRestartState)
                 .To<AIRestartState>()
                 .AsTransient();

        Container.Bind<IState>()
                 .WithId(CharacterState.AIMoveToFixedLocationState)
                 .To<AIMoveToFixedLocationState>()
                 .AsSingle();

        Container.Bind<IState>()
                 .WithId(CharacterState.DecideState)
                 .To<DecideState>()
                 .AsSingle();

        Container.Bind<IState>()
                 .WithId(CharacterState.AISyncWithObstacleState)
                 .To<AISyncWithObstacleState>()
                 .AsSingle();

        Container.Bind<IState>()
                 .WithId(CharacterState.AIMoveInRotatingPlatformState)
                 .To<AIMoveInRotatingPlatformState>()
                 .AsSingle();

        Container.Bind<IState>()
                .WithId(CharacterState.AIMoveTowardsCenterState)
                .To<AIMoveTowardsCenterState>()
                .AsSingle();

        Container.Bind<IState>()
                .WithId(CharacterState.AIEndGameState)
                .To<AIEndGameState>()
                .AsSingle();

        Container.Bind<IState>()
                .WithId(CharacterState.AICelebrateState)
                .To<AICelebrateState>()
                .AsSingle();

        Container.Bind<EndGameWaitPoints>()
                .FromInstance(_endGameWaitPoints)
                .AsSingle();
    }
}
