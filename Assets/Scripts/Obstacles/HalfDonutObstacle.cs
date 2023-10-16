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
            Sequence moveInSequence = DOTween.Sequence();
            moveInSequence.Append(_stickTransform.DOLocalMoveX(_moveInTargetX, 1f));
            moveInSequence.onComplete = () => _obstacleData.SetIsObstaclePassable(true);

            Sequence moveOutSequence = DOTween.Sequence();
            moveOutSequence.Append(_stickTransform.DOLocalMoveX(_moveOutTargetX, 1f));
            moveOutSequence.onComplete = () => _obstacleData.SetIsObstaclePassable(false);

            Sequence totalSequence = DOTween.Sequence();

            totalSequence.Append(moveInSequence)
                         .Append(moveOutSequence)
                         .SetLoops(-1, LoopType.Restart);
        }
    }
}
