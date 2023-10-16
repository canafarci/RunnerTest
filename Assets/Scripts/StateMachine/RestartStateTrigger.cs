using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class RestartStateTrigger : MonoBehaviour
    {
        private CharacterStateMachine _stateMachine;
        private static int obstacleLayer;
        private const string _checkLayerName = "Obstacle";

        private void Start()
        {
            obstacleLayer = LayerMask.NameToLayer(_checkLayerName);
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == obstacleLayer)
            {
                _stateMachine.ChangeStateToResetState();
            }
        }

        [Inject]
        private void Init(CharacterStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}
