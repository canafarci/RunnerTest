using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runner.Obstacles
{
    public class HalfDonutObstacle : Obstacle
    {
        private const float _moveInTargetX = -0.1245f;
        private const float _moveOutTargetX = 0.1542f;
        [SerializeField] private Transform _stickTransform;

        private void Start()
        {
            Sequence moveInSequence = CreateMoveSequence(true, 0.8f);

            Sequence moveOutSequence = CreateMoveSequence(false, 1.6f);

            Sequence totalSequence = DOTween.Sequence();

            totalSequence.Append(moveInSequence)
                         .Append(moveOutSequence)
                         .SetLoops(-1, LoopType.Restart);
        }

        private Sequence CreateMoveSequence(bool isPassableAfter, float duration)
        {
            Sequence moveSequence = DOTween.Sequence();

            float target = isPassableAfter ? _moveInTargetX : _moveOutTargetX;

            moveSequence.Append(_stickTransform.DOLocalMoveX(target, duration));
            moveSequence.onComplete = () => _obstacleData.SetIsObstaclePassable(isPassableAfter);

            return moveSequence;
        }
    }
}
