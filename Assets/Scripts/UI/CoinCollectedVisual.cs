using DG.Tweening;
using Runner.GameVariables;
using UnityEngine;
using Zenject;

namespace Runner.UI
{
    public class CoinCollectedVisual : MonoBehaviour
    {
        private CoinVisual.Pool _coinVisualPool;
        [SerializeField] private RectTransform _target;
        private RectTransform _rectTransform;

        private void Start()
        {
            CollectableCoin.OnCoinCollected += OnCoinCollected_CoinCollectedHandler;
        }

        private void OnCoinCollected_CoinCollectedHandler(Vector3 position)
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnCoinVisual(position);
            }
        }

        private void SpawnCoinVisual(Vector3 startPos)
        {
            CoinVisual coin = _coinVisualPool.Spawn(startPos, _rectTransform);

            Vector3 intermediatePos = (startPos + _target.position) / 2f;
            intermediatePos += Random.insideUnitSphere * Screen.width / 10f;

            Vector3[] path = new Vector3[] { startPos, intermediatePos, _target.position };

            Tween tween = coin.transform.DOPath(path, 1f, PathType.CatmullRom, PathMode.Full3D)
                .SetEase(Ease.InQuad);

            tween.onComplete = () => _coinVisualPool.Despawn(coin);
        }

        [Inject]
        private void Init(RectTransform rectTransform, CoinVisual.Pool coinVisualPool)
        {
            _rectTransform = rectTransform;
            _coinVisualPool = coinVisualPool;
        }
    }
}
