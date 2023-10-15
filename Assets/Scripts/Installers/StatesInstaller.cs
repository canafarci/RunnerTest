using Zenject;
using Runner.StateMachine;
using Runner.PlayerMovement;
using UnityEngine.AI;

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

            Container.Bind<PlayerMover>().
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

            Container.Bind<NavMeshAgent>().
                To<NavMeshAgent>().
                FromComponentInChildren().
                AsTransient();
        }
    }
}
