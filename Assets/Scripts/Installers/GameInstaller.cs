using Zenject;
using Runner.Input;
using UnityEngine;

namespace Runner.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private GameObject _playerEntity;
        public override void InstallBindings()
        {
            //Input
            Container.Bind<Joystick>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IInputReader>().To<JoystickInputReader>().AsSingle();
            Container.Bind<CharacterController>().FromNewComponentOn(_playerEntity).AsSingle();

        }

    }
}