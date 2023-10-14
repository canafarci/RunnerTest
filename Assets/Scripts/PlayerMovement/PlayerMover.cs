using Runner.Input;
using UnityEngine;
using Zenject;

namespace Runner.PlayerMovement
{
    public class PlayerMover
    {

        //dependencies
        private IInputReader _inputReader;
        private CharacterController _characterController;

        public void Move()
        {
            Vector2 input = _inputReader.GetInput();
            if (input == Vector2.zero) return; //pop stack frame if no input is detected

            Vector3 movement = new Vector3(input.x, 0f, input.y);

            const float speed = 5f;

            _characterController.Move(speed * Time.deltaTime * movement);
        }

        //initialization
        [Inject]
        private void Init(IInputReader reader, CharacterController characterController)
        {
            _inputReader = reader;
            _characterController = characterController;

            _characterController.height = 2.4f;
            _characterController.center = new Vector3(0f, 1.2f, 0f);
        }


    }
}
