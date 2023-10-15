using Zenject;
using Runner.Input;
using UnityEngine;
using Runner.ScriptableObjects;
using Runner.StateMachine;
using Runner.PlayerMovement;

namespace Runner.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private GameObject _playerEntity;
        [SerializeField] private PlayerConfigSO _playerConfiguration;
        public override void InstallBindings()
        {
            //Input
            Container.Bind<Joystick>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<IInputReader>()
                .To<JoystickInputReader>()
                .AsSingle();

            Container.Bind<CharacterController>()
                .WithId(MovementComponents.PlayerCharacterController)
                .FromNewComponentOn(_playerEntity)
                .AsSingle();

            Container.Bind<CharacterController>()
                .WithId(CharacterState.AIMoveState)
                .FromComponentInChildren()
                .AsTransient();

            Container.Bind<PlayerConfigSO>()
                .FromInstance(_playerConfiguration)
                .AsSingle();

        }
    }
}