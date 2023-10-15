using System.Collections;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace Runner.StateMachine.Tests
{
    public class state_machine_tests : ZenjectIntegrationTestFixture
    {
        private Mock<IState> _mockState;
        private Mock<IState> _mockNextState;

        private void CommonInstall()
        {
            //Arrange
            _mockState = new Mock<IState>();
            _mockNextState = new Mock<IState>();

            PreInstall();

            Container.Bind<IState>()
                .WithId(CharacterState.PlayerWaitForStartState)
                .FromInstance(_mockState.Object).
                AsSingle();

            Container.Bind<PlayerStateMachine>().FromNewComponentOnNewGameObject().AsSingle();

            PostInstall();
        }

        [UnityTest]
        public IEnumerator should_call_enter_on_next_state_when_current_state_changes()
        {
            CommonInstall();
            yield return null; //wait for one frame

            //Arrange
            PlayerStateMachine stateMachine = Container.Resolve<PlayerStateMachine>();

            _mockState.Setup(state => state.Tick())
                     .Returns(CharacterState.PlayerMoveState);

            //Act
            yield return null; //wait for one frame
            //Assert
            _mockNextState.Verify(state => state.Enter(), Times.Once);
        }

        [UnityTest]
        public IEnumerator should_call_exit_on_first_state_when_first_state_changes()
        {
            CommonInstall();
            yield return null; //wait for one frame

            //Arrange
            PlayerStateMachine stateMachine = Container.Resolve<PlayerStateMachine>();

            _mockState.Setup(state => state.Tick())
                     .Returns(CharacterState.PlayerMoveState);

            //Act
            yield return null; //wait for one frame
            //Assert
            _mockState.Verify(state => state.Exit(), Times.Once);
        }
    }
}
