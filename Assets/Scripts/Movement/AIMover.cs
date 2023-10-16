using System.Collections;
using System.Collections.Generic;
using Runner.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Runner.Movement
{
    public class AIMover : Mover, IMoveable
    {

        public void TickMovement(Vector2 input)
        {
            Move(input);
        }

        //Initialization
        [Inject]
        private void Init(CharacterController characterController,
                          AIConfigSO config)
        {
            _characterController = characterController;
            _speed = config.AISpeed;
        }
    }
}
