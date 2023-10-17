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

        private void Start()
        {
            Sequence passableSequence = CreateMoveSequence(true);

            Sequence unpassableSequence = CreateMoveSequence(false);

            CreateRotateTween();

            Sequence totalSequence = DOTween.Sequence();
            totalSequence.Append(passableSequence)
                         .Append(unpassableSequence)
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

        private Sequence CreateMoveSequence(bool isPassableAfter)
        {
            Sequence moveSequence = DOTween.Sequence();

            float target = isPassableAfter ? _leftX : _rightX;

            moveSequence.Append(_stickTransform.DOLocalMoveX(target, _duration));
            moveSequence.onComplete = () => _obstacleData.SetIsObstaclePassable(isPassableAfter);

            return moveSequence;
        }


    }
}
