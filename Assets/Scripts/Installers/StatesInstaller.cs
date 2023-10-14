using System;
using Runner.State;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Runner.Installers
{
    public class StatesInstaller : MonoInstaller<StatesInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IState>().
                WithId(BindingID.PlayerWaitForStartState).
                To<PlayerWaitForStartState>().
                FromComponentInChildren().
                AsTransient();

            Container.Bind<IState>().
                WithId(BindingID.PlayerMoveState).
                To<PlayerMoveState>().
                FromComponentInChildren().
                AsTransient();
        }
    }
}
