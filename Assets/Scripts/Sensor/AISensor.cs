using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.Obstacles;

namespace Runner.Sensors
{
    public class AISensor : MonoBehaviour
    {
        private readonly int _checkLayerMask = 1 << 10; //10 is ObstacleDataHolder layer
        private readonly float _checkDistance = 4f;

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
            Ray ray = new Ray(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward));

            if (Physics.Raycast(ray, out RaycastHit hit, _checkDistance, _checkLayerMask))
            {
                Obstacle obstacle = hit.transform.GetComponent<Obstacle>();
                print(obstacle);
                return obstacle;
            }
            else
            {
                return null;
            }

        }
    }
}
