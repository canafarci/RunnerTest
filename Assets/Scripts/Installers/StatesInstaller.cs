using Zenject;
using Runner.StateMachine;
using Runner.Movement;
using UnityEngine.AI;
using UnityEngine;
using Runner.Sensors;

namespace Runner.Installers
{
    public class StatesInstaller : MonoInstaller<StatesInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IState>()
                     .WithId(CharacterState.PlayerWaitForStartState)
                     .To<PlayerWaitForStartState>()
                     .AsSingle();

            Container.Bind<IState>()
                     .WithId(CharacterState.PlayerMoveState)
                     .To<PlayerMoveState>()
                     .AsSingle();

            Container.Bind<IState>()
                     .WithId(CharacterState.PlayerRestartState)
                     .To<PlayerRestartState>()
                     .FromComponentInChildren()
                     .AsSingle();

            Container.Bind<CharacterStateMachine>()
                     .FromComponentInChildren()
                     .AsTransient();


            BindAIStates();
        }

        private void BindAIStates()
        {
            Container.Bind<IState>()
                     .WithId(CharacterState.AIWaitState)
                     .To<AIWaitState>()
                     .AsTransient();

            Container.Bind<IState>()
                     .WithId(CharacterState.AIRandomMoveState)
                     .To<AIRandomMoveState>()
                     .FromComponentInChildren()
                     .AsTransient();

            Container.Bind<IState>()
                     .WithId(CharacterState.AIRestartState)
                     .To<AIRestartState>()
                     .FromComponentInChildren()
                     .AsTransient();

            Container.Bind<IState>()
                     .WithId(CharacterState.AIMoveToFixedLocationState)
                     .To<AIMoveToFixedLocationState>()
                     .FromComponentInChildren()
                     .AsTransient();

            Container.Bind<IState>()
                     .WithId(CharacterState.DecideState)
                     .To<DecideState>()
                     .FromComponentInChildren()
                     .AsTransient();

            Container.Bind<IState>()
                     .WithId(CharacterState.AISyncWithObstacleState)
                     .To<AISyncWithObstacleState>()
                     .FromComponentInChildren()
                     .AsTransient();

            Container.Bind<IState>()
                     .WithId(CharacterState.AIMoveInRotatingPlatformState)
                     .To<AIMoveInRotatingPlatformState>()
                     .FromComponentInChildren()
                     .AsTransient();

            Container.Bind<IState>()
                     .WithId(CharacterState.AIMoveTowardsCenterState)
                     .To<AIMoveTowardsCenterState>()
                     .FromComponentInChildren()
                     .AsTransient();

            BindAIDependencies();
        }

        private void BindAIDependencies()
        {
            Container.Bind<AIStateVariables>()
                    .FromComponentInChildren()
                    .AsTransient();

            Container.Bind<AISensor>()
                    .FromComponentInChildren()
                    .AsTransient();
        }
    }
}
