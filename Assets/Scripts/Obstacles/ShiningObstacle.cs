using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runner.Obstacles
{
    public class ShiningObstacle : Obstacle
    {
        [SerializeField] private Transform _stickTransform;
        private const float _leftX = -7f;
        private const float _rightX = 7f;
        private const float _duration = 1.6f;
        private Sequence _moveLeftSequence;
        private Sequence _moveRightSequence;

        private void Start()
        {
            _moveLeftSequence = CreateMoveSequence(_leftX);

            _moveRightSequence = CreateMoveSequence(_rightX);

            CreateRotateTween();

            Sequence totalSequence = DOTween.Sequence();
            totalSequence.Append(_moveLeftSequence)
                         .Append(_moveRightSequence)
                         .SetLoops(-1, LoopType.Restart);

            CreateRotateTween();
        }

        private void CreateRotateTween()
        {

            _stickTransform.DOLocalRotate(new Vector3(0f, 360f, 0f),
                        _duration,
                        RotateMode.FastBeyond360)
                        .SetRelative(true)
                        .SetEase(Ease.Linear)
                        .SetLoops(-1, LoopType.Restart);
        }

        private Sequence CreateMoveSequence(float target)
        {
            Sequence moveSequence = DOTween.Sequence();

            moveSequence.Append(
                _stickTransform.DOLocalMoveX(target, _duration)
                .SetEase(Ease.Linear));

            return moveSequence;
        }

        private void Update()
        {
            if (_moveRightSequence.ElapsedPercentage() > 0.25f)
            {
                _obstacleData.SetIsObstaclePassable(true);
            }
            else
            {
                _obstacleData.SetIsObstaclePassable(false);
            }
        }


    }
}
