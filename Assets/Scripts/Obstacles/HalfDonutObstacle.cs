using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runner.Obstacles
{
    public class HalfDonutObstacle : Obstacle
    {
        [SerializeField] private Transform _stickTransform;
        private const float _moveInTargetX = -0.1245f;
        private const float _moveOutTargetX = 0.1542f;
        private Sequence _moveOutSequence;
        private Sequence _moveInSequence;
        private void Start()
        {
            _moveInSequence = CreateMoveSequence(true, 0.8f);

            _moveOutSequence = CreateMoveSequence(false, 1.6f);

            Sequence totalSequence = DOTween.Sequence();

            totalSequence.Append(_moveInSequence)
                         .Append(_moveOutSequence)
                         .SetLoops(-1, LoopType.Restart);
        }

        private Sequence CreateMoveSequence(bool isMovingIn, float duration)
        {
            Sequence moveSequence = DOTween.Sequence();

            float target = isMovingIn ? _moveInTargetX : _moveOutTargetX;

            moveSequence.Append(_stickTransform.DOLocalMoveX(target, duration));

            return moveSequence;
        }

        private void Update()
        {
            if (_moveOutSequence.ElapsedPercentage() > 0.75f)
            {
                _obstacleData.SetIsObstaclePassable(false);
            }
            else if (_moveOutSequence.ElapsedPercentage() > 0.15f)
            {
                _obstacleData.SetIsObstaclePassable(true);
            }
        }
    }
}
