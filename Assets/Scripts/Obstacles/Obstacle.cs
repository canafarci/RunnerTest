using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Runner.Containers;
using UnityEngine;

namespace Runner.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] protected ObstacleData _obstacleData;
        public ObstacleData GetObstacleData() => _obstacleData;
    }
}
