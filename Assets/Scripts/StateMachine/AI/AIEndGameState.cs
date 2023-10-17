using System.Collections;
using System.Collections.Generic;
using Runner.Containers;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class AIEndGameState : MonoBehaviour, IState
    {
        private EndGameWaitPoints _waitPoints;
        private AIStateVariables _stateVariables;
        private Rigidbody _rigidbody;

        public void Enter()
        {
            SetTargetPosition();
            _stateVariables.SetHasReachedEndGame();
            _rigidbody.isKinematic = true;
        }

        private void SetTargetPosition()
        {
            WaitPoint point = _waitPoints.GetWaitPoint();
            Vector3 targetPosition = point.transform.position;
            _stateVariables.SetTargetPosition(targetPosition);
        }

        public void Exit() { }

        public CharacterState Tick()
        {
            return CharacterState.AIMoveToFixedLocationState;
        }

        [Inject]
        private void Init(EndGameWaitPoints waitPoints, AIStateVariables stateVariables, Rigidbody rigidbody)
        {
            _waitPoints = waitPoints;
            _stateVariables = stateVariables;
            _rigidbody = rigidbody;
        }

    }
}
