using System.Collections;
using System.Collections.Generic;
using Runner.Creation;
using Runner.Animation;
using Runner.Movement;
using Runner.StateMachine;
using UnityEngine;
using Zenject;

public class PlayerCharacterInstaller : Installer<PlayerCharacterInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerCharacter>().AsSingle();

        Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
        Container.Bind<Rigidbody>().FromComponentOnRoot().AsSingle();
        Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesAndSelfTo<CharacterAnimationController>().AsSingle();

        Container.Bind<IMoveable>().To<PlayerMover>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle();

        Container.Bind<IState>()
                .WithId(CharacterState.PlayerWaitState)
                .To<PlayerWaitForStartState>()
                .AsSingle();

        Container.Bind<IState>()
                 .WithId(CharacterState.PlayerMoveState)
                 .To<PlayerMoveState>()
                 .AsSingle();

        Container.Bind<IState>()
                 .WithId(CharacterState.PlayerRestartState)
                 .To<PlayerRestartState>()
                 .AsSingle();

        Container.Bind<IState>()
                 .WithId(CharacterState.PlayerPaintState)
                 .To<PlayerPaintState>()
                 .AsSingle();

        var restartState = Container.ResolveId<IState>(CharacterState.PlayerRestartState) as PlayerRestartState;
        Container.Bind<IRestartable>().FromInstance(restartState);
    }
}
