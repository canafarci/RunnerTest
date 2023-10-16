using UnityEngine;

namespace Runner.Movement
{
    public interface IMoveable
    {
        public void TickMovement(Vector2 input);
    }
}