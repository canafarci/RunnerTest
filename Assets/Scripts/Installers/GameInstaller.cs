using Zenject;
using Runner.Input;
using UnityEngine;
using Runner.ScriptableObjects;

namespace Runner.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private GameObject _playerEntity;
        [SerializeField] private PlayerConfigSO _playerConfiguration;
        public override void InstallBindings()
        {
            //Input
            Container.Bind<Joystick>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IInputReader>().To<JoystickInputReader>().AsSingle();
            Container.Bind<CharacterController>().FromNewComponentOn(_playerEntity).AsSingle();
            Container.Bind<PlayerConfigSO>().FromInstance(_playerConfiguration);

        }
    }
}