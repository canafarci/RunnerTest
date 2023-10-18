using Zenject;
using Runner.StateMachine;
using UnityEngine;
using Runner.Sensors;
using Runner.Containers;

namespace Runner.Installers
{
    public class StatesInstaller : MonoInstaller<StatesInstaller>
    {
        [SerializeField] private EndGameWaitPoints _endGameWaitPoints;
        public override void InstallBindings()
        {
            BindPlayerStates();

            Container.Bind<CharacterStateMachine>()
                     .FromComponentInChildren()
                     .AsTransient();


            BindAIStates();
        }

        private void BindPlayerStates()
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

            Container.Bind<IState>()
                     .WithId(CharacterState.PlayerPaintState)
                     .To<PlayerPaintState>()
                     .FromComponentInChildren()
                     .AsSingle();
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

            Container.Bind<IState>()
                     .WithId(CharacterState.AIEndGameState)
                     .To<AIEndGameState>()
                     .FromComponentInChildren()
                     .AsTransient();

            Container.Bind<IState>()
                     .WithId(CharacterState.AICelebrateState)
                     .To<AICelebrateState>()
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

            Container.Bind<EndGameWaitPoints>()
                    .FromInstance(_endGameWaitPoints)
                    .AsSingle();
        }
    }
}
