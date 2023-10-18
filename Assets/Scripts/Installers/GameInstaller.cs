using Zenject;
using Runner.Input;
using UnityEngine;
using Runner.ScriptableObjects;
using Cinemachine;
using Runner.Movement;
using Runner.StateMachine;

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

            Container.Bind<Rigidbody>()
                .FromComponentInChildren()
                .AsTransient();

            Container.Bind<Rigidbody>()
                .WithId(MovementComponents.PlayerRigidbody)
                .FromComponentOn(_playerEntity)
                .AsTransient();

            BindScriptableObjects();

            Container.Bind<IMoveable>()
                .WithId(MovementComponents.PlayerRigidbody)
                .To<PlayerMover>()
                .FromComponentOn(_playerEntity)
                .AsSingle();

            Container.Bind<IMoveable>()
                .WithId(MovementComponents.AICharacterController)
                .To<AIMover>()
                .FromComponentInChildren()
                .AsTransient();

            Container.Bind<CinemachineVirtualCamera>()
                .FromComponentInChildren()
                .AsTransient();

            Container.Bind<PlayerPaintState>()
                .FromComponentInHierarchy()
                .AsCached();

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

    public enum ComponentID
    {
        PlayerPaintState
    }
}