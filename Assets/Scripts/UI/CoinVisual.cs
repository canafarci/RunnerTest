using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Runner.UI
{
    public class CoinVisual : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Spawn(Vector3 position, RectTransform parent)
        {
            _rectTransform.SetParent(parent);
            _rectTransform.position = position;
        }

        [Inject]
        private void Init(RectTransform rectTransform)
        {
            _rectTransform = rectTransform;
        }

        public class Pool : MonoMemoryPool<Vector3, RectTransform, CoinVisual>
        {
            protected override void Reinitialize(Vector3 position, RectTransform parent, CoinVisual coin)
            {
                coin.Spawn(position, parent);
            }
        }
    }
}
