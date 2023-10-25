using Zenject;
using Runner.Input;
using UnityEngine;
using Runner.ScriptableObjects;
using Cinemachine;
using Runner.Movement;
using Runner.StateMachine;
using Runner.GameVariables;
using Runner.Creation;
using Runner.Containers;
using Runner.Camera;

namespace Runner.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private PlayerConfigSO _playerConfiguration;
        [SerializeField] private AIConfigSO _aiConfiguration;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _aiPrefab;
        [SerializeField] private Transform[] _aiSpawnPositions;
        [SerializeField] private Transform _playerSpawnPosition;
        [SerializeField] private EndGameWaitPoints _endGameWaitPoints;
        [SerializeField] private CinemachineVirtualCamera _playCam;
        [SerializeField] private CinemachineVirtualCamera _paintCam;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterSpawner>().
                AsSingle();

            Container.Bind<Transform[]>()
                .FromInstance(_aiSpawnPositions)
                .WhenInjectedInto<CharacterSpawner>();

            Container.Bind<Transform>()
                .FromInstance(_playerSpawnPosition)
                .WhenInjectedInto<CharacterSpawner>();

            Container.Bind<EndGameWaitPoints>().FromInstance(_endGameWaitPoints);


            Container.BindFactory<AICharacter, AICharacter.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefabInstaller<AICharacterInstaller>(_aiPrefab);

            Container.BindFactory<PlayerCharacter, PlayerCharacter.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefabInstaller<PlayerCharacterInstaller>(_playerPrefab);

            //Input
            Container.Bind<Joystick>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<IInputReader>()
                .To<JoystickInputReader>()
                .AsSingle();

            BindScriptableObjects();

            BindCameras();

            Container.Bind<GameDynamicData>()
                .AsSingle();
        }

        private void BindCameras()
        {
            Container.Bind<CinemachineVirtualCamera>()
                .WithId(CameraID.PlayCamera)
                .FromInstance(_playCam);

            Container.Bind<CinemachineVirtualCamera>()
                .WithId(CameraID.PaintCamera)
                .FromInstance(_paintCam);

            Container.BindInterfacesAndSelfTo<CameraTargetSetter>()
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<CameraChanger>()
                .AsSingle();
        }

        private void BindScriptableObjects()
        {
            Container.Bind<PlayerConfigSO>()
                .FromInstance(_playerConfiguration)
                .AsSingle();

            Container.Bind<AIConfigSO>()
                .FromInstance(_aiConfiguration)
                .AsSingle()
                .NonLazy();
        }
    }

    public enum ComponentID
    {
        PlayerPaintState
    }
}