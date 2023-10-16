using System.Runtime.CompilerServices;
using Runner.ScriptableObjects;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Runner.Movement
{
    public class PlayerMover : Mover, IMoveable
    {
        public void TickMovement(Vector2 input)
        {
            if (input == Vector2.zero) return; //pop stack frame if no input is detected

            Move(input);
        }

        [Inject]
        private void Init(Rigidbody rigidbody,
                          PlayerConfigSO config)
        {
            _speed = config.PlayerSpeed;
            _rigidbody = rigidbody;
        }
    }

    public enum MovementComponents
    {
        PlayerRigidbody,
        AICharacterController
    }
}
