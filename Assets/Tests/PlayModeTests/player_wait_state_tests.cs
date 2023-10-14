using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace Runner.State.Tests
{
    public class player_wait_state_tests : ZenjectIntegrationTestFixture
    {
        private Mock<IState> _mockNextState;
        private void CommonInstall()
        {
            _mockNextState = new Mock<IState>();
            GameObject obj = new GameObject();
            //Arrange

            PreInstall();

            Container.Bind<IState>().
                WithId(BindingID.PlayerMoveState).
                FromInstance(_mockNextState.Object).
                AsSingle();

            Container.Bind<IState>().
                WithId(BindingID.PlayerWaitForStartState).
                To<PlayerWaitForStartState>().
                FromNewComponentOn(obj).
                AsSingle();

            Container.Bind<PlayerStateMachine>().FromNewComponentOn(obj).AsSingle();

            PostInstall();
        }

        [Inject(Id = BindingID.PlayerWaitForStartState)] IState _waitState;

        [UnityTest]
        public IEnumerator wait_time_is_set_when_state_is_created()
        {
            //Arrange
            CommonInstall();
            yield return null;

            //Act
            float? timeLeft = GetInstanceField(typeof(PlayerWaitForStartState), _waitState, "_waitDuration") as float?;

            //Assert
            Assert.IsNotNull(timeLeft);
            Assert.IsTrue(timeLeft > 0f);
        }

        [UnityTest]
        public IEnumerator wait_time_is_lower_than_maximum_after_time_passes()
        {
            //Arrange
            CommonInstall();
            yield return null;

            //Act
            float? maxTime = GetInstanceField(typeof(PlayerWaitForStartState), _waitState, "_waitDuration") as float?;
            yield return new WaitForSeconds(0.2f);
            float? timeLeft = GetInstanceFieldOnBaseClass(typeof(PlayerWaitForStartState), _waitState, "_timeLeft") as float?;

            //Assert
            Assert.IsTrue(timeLeft < maxTime);
        }

        private static object GetInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo field = type.GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }
        private static object GetInstanceFieldOnBaseClass(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo field = type.BaseType.GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }
    }
}
