using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movement
{
    public abstract class Mover : MonoBehaviour
    {
        protected Rigidbody _rigidbody;
        protected float _speed;

        protected void Move(Vector2 input)
        {
            Vector3 direction = new Vector3(input.x, 0f, input.y);
            Vector3 normalizedDirection = _speed * Time.fixedDeltaTime * direction;

            _rigidbody.MovePosition(transform.position + normalizedDirection);
        }
    }
}
