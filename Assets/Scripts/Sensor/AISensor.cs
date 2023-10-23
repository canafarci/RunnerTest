using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.Obstacles;
using Runner.Containers;
using Zenject;

namespace Runner.Sensors
{
    public class AISensor : IInitializable
    {
        private int _checkLayerMask;
        private readonly Transform _transform;
        private readonly float _checkDistance = 5f;

        private AISensor(Transform transform)
        {
            _transform = transform;
        }

        public void Initialize()
        {
            _checkLayerMask = 1 << 10; //10 is ObstacleDataHolder
        }

        public ObstacleData CheckObstacles()
        {
            ObstacleData data = null;

            Obstacle obstacle = RaycastObstacle();

            if (obstacle != null)
            {
                data = obstacle.GetObstacleData();
            }

            return data;
        }

        private Obstacle RaycastObstacle()
        {
            Ray ray = new Ray(_transform.position, Vector3.forward);


            if (Physics.Raycast(ray,
                                out RaycastHit hit,
                                _checkDistance,
                                _checkLayerMask,
                                QueryTriggerInteraction.Collide))
            {
                Obstacle obstacle = hit.transform.GetComponent<Obstacle>();
                return obstacle;
            }
            else
            {
                return null;
            }

        }
    }
}
