using Runner.Input;
using Runner.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Runner.PlayerMovement
{
    public class PlayerMover
    {
        //variables
        private readonly float _speed;
        //dependencies
        private readonly IInputReader _inputReader;
        private readonly CharacterController _characterController;

        public void Move()
        {
            Vector2 input = _inputReader.GetInput();
            if (input == Vector2.zero) return; //pop stack frame if no input is detected

            Vector3 movement = new Vector3(input.x, 0f, input.y);

            _characterController.Move(_speed * Time.deltaTime * movement);
        }

        private PlayerMover(IInputReader reader,
                            [Inject(Id = MovementComponents.PlayerCharacterController)] CharacterController characterController,
                            PlayerConfigSO config)
        {
            _inputReader = reader;
            _characterController = characterController;
            _speed = config.PlayerSpeed;

            _characterController.height = config.PlayerHeight;
            _characterController.center = new Vector3(0f, config.PlayerHeight / 2f, 0f);
        }
    }

    public enum MovementComponents
    {
        PlayerCharacterController
    }
}
