using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runner.Obstacles
{
    public class RotatingObstacle : Obstacle
    {
        [SerializeField] private Transform _rotatingStick;
        private const float _duration = 4f;
        private readonly Vector3 _targetRotation = new Vector3(0, 360f, 0f);

        void Start()
        {
            _rotatingStick.DOLocalRotate(_targetRotation,
                                    _duration,
                                    RotateMode.FastBeyond360)
                                    .SetRelative(true)
                                    .SetLoops(-1, LoopType.Restart)
                                    .SetEase(Ease.Linear);
        }

        private void Update()
        {
            if (_rotatingStick.transform.eulerAngles.y > 0f && _rotatingStick.transform.eulerAngles.y < 115f)
            {
                _obstacleData.SetIsObstaclePassable(false);
            }
            else
            {
                _obstacleData.SetIsObstaclePassable(true);
            }
        }
    }
}