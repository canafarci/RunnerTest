using Zenject;
using Runner.Input;
using UnityEngine;
using Runner.ScriptableObjects;
using Runner.StateMachine;
using Runner.Movement;

namespace Runner.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private PlayerConfigSO _playerConfiguration;
        [SerializeField] private AIConfigSO _aiConfiguration;
        [SerializeField] private GameObject _playerEntity;

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
                .FromComponentInChildren()
                .AsTransient();

            Container.Bind<CharacterController>()
                .WithId(MovementComponents.PlayerCharacterController)
                .FromComponentOn(_playerEntity)
                .AsTransient();

            BindScriptableObjects();

            Container.Bind<IMoveable>()
                .WithId(MovementComponents.PlayerCharacterController)
                .To<PlayerMover>()
                .FromComponentOn(_playerEntity)
                .AsSingle();

            Container.Bind<IMoveable>()
                .WithId(MovementComponents.AICharacterController)
                .To<AIMover>()
                .FromComponentInChildren()
                .AsTransient();
        }

        private void BindScriptableObjects()
        {
            Container.Bind<PlayerConfigSO>()
                .FromInstance(_playerConfiguration)
                .AsSingle();

            Container.Bind<AIConfigSO>()
                .FromInstance(_aiConfiguration)
                .AsSingle();
        }
    }
}