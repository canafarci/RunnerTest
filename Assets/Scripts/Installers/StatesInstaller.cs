using Zenject;
using Runner.StateMachine;
using Runner.Movement;
using UnityEngine.AI;
using UnityEngine;

namespace Runner.Installers
{
    public class StatesInstaller : MonoInstaller<StatesInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IState>().
                WithId(CharacterState.PlayerWaitForStartState).
                To<PlayerWaitForStartState>().
                AsSingle();

            Container.Bind<IState>().
                WithId(CharacterState.PlayerMoveState).
                To<PlayerMoveState>().
                AsSingle();

            Container.Bind<IState>().
                WithId(CharacterState.PlayerRestartState).
                To<PlayerRestartState>().
                FromComponentInChildren().
                AsSingle();

            Container.Bind<IState>().
                WithId(CharacterState.DecideState).
                To<DecideState>().
                AsTransient();

            Container.Bind<IState>().
                WithId(CharacterState.AIWaitState).
                To<AIWaitState>().
                AsTransient();

            Container.Bind<IState>().
                WithId(CharacterState.AIMoveState).
                To<AIMoveState>().
                FromComponentInChildren().
                AsTransient();

            Container.Bind<IState>().
                WithId(CharacterState.AIRestartState).
                To<AIRestartState>().
                FromComponentInChildren().
                AsTransient();

            Container.Bind<NavMeshAgent>().
                To<NavMeshAgent>().
                FromComponentInChildren().
                AsTransient();
        }
    }
}
