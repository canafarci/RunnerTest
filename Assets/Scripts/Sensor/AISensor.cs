using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.Obstacles;
using Runner.Containers;

namespace Runner.Sensors
{
    public class AISensor : MonoBehaviour
    {
        private int _checkLayerMask;
        private readonly float _checkDistance = 5f;

        private void Start()
        {
            _checkLayerMask = LayerMask.NameToLayer("ObstacleDataHolder");
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
            Ray ray = new Ray(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward));

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
