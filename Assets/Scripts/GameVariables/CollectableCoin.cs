using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Runner.GameVariables
{
    public class CollectableCoin : MonoBehaviour
    {
        private const int _moneyIncreaseAmount = 20;
        public static event Action<Vector3> OnCoinCollected;
        private void Start()
        {
            gameObject.AddComponent<ObservableTriggerTrigger>()
                .OnTriggerEnterAsObservable()
                .Subscribe(x => IncreaseMoney());
        }

        private void IncreaseMoney()
        {
            GameDynamicData.GetInstance().IncreaseMoney(_moneyIncreaseAmount);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

            OnCoinCollected?.Invoke(screenPos);
            Destroy(gameObject);
        }

    }
}
