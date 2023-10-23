using System.Collections;
using System.Collections.Generic;
using Runner.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Runner.Movement
{
    public class AIMover : Mover, IMoveable
    {
        public AIMover(AIConfigSO config, Transform transform, Rigidbody rigidbody) : base(transform, rigidbody)
        {
            _speed = config.AISpeed;
        }

        public void TickMovement(Vector2 input)
        {
            Move(input);
        }
    }
}
