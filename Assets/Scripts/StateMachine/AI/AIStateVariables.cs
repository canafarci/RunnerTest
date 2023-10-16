using System.Collections;
using System.Collections.Generic;
using Runner.Obstacles;
using UnityEngine;

namespace Runner.StateMachine
{
    public class AIStateVariables : MonoBehaviour
    {
        public ObstacleData CurrentObstacleData { get; set; }
    }
}
