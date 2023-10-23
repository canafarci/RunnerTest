using System.Runtime.CompilerServices;
using Runner.ScriptableObjects;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Runner.Movement
{
    public class PlayerMover : Mover, IMoveable
    {
        public PlayerMover(PlayerConfigSO config, Transform transform, Rigidbody rigidbody) : base(transform, rigidbody)
        {
            _speed = config.PlayerSpeed;
        }

        public void TickMovement(Vector2 input)
        {
            if (input == Vector2.zero) return; //pop stack frame if no input is detected

            Move(input);
        }
    }

    public enum MovementComponents
    {
        PlayerRigidbody,
        AICharacterController
    }
}
