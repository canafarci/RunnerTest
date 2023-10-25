using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movement
{
    public class PositionRandomizer
    {
        public Vector3 RandomizeDestinationPoint(Vector3 position, float radius)
        {

            Vector3 noise = GetRandomPositionInSphere(radius);
            position += noise;
            return position;
        }

        private Vector3 GetRandomPositionInSphere(float radius)
        {
            Vector3 noise = radius * UnityEngine.Random.insideUnitSphere;
            noise.y = 0f;
            return noise;
        }
    }
}
