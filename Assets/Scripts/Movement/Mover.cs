using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movement
{
    public abstract class Mover
    {
        protected Rigidbody _rigidbody;
        private Transform _transform;
        protected float _speed;

        protected Mover(Transform transform, Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
            _transform = transform;
        }

        protected void Move(Vector2 input)
        {
            Vector3 direction = new Vector3(input.x, 0f, input.y);
            Vector3 normalizedDirection = _speed * Time.fixedDeltaTime * direction;

            _rigidbody.MovePosition(_transform.position + normalizedDirection);
        }
    }
}
