using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movement
{
    public abstract class Mover : MonoBehaviour
    {
        protected CharacterController _characterController;
        protected float _speed;

        protected void Move(Vector2 input)
        {
            float gravity = 0f;

            Vector3 direction = new Vector3(input.x, gravity, input.y);

            if (!_characterController.isGrounded) //character is falling
            {
                gravity = -9.81f;
            }

            direction.y = gravity;

            _characterController.Move(_speed * Time.deltaTime * direction);
        }
    }
}
