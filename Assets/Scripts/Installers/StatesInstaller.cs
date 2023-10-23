using Zenject;
using Runner.StateMachine;
using UnityEngine;
using Runner.Sensors;
using Runner.Containers;

namespace Runner.Installers
{
    public class StatesInstaller : MonoInstaller<StatesInstaller>
    {
        public override void InstallBindings()
        {

        }

        private void BindPlayerStates()
        {
        }

        private void BindAIStates()
        {


            BindAIDependencies();
        }

        private void BindAIDependencies()
        {


        }
    }
}
