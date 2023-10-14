using Zenject;
using Runner.State;
using Runner.PlayerMovement;

namespace Runner.Installers
{
    public class StatesInstaller : MonoInstaller<StatesInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IState>().
                WithId(BindingID.PlayerWaitForStartState).
                To<PlayerWaitForStartState>().
                AsSingle();

            Container.Bind<IState>().
                WithId(BindingID.PlayerMoveState).
                To<PlayerMoveState>().
                AsSingle();

            Container.Bind<PlayerMover>().
                AsSingle();

        }
    }
}
