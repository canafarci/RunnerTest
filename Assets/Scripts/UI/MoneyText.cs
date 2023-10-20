using System.Collections;
using System.Collections.Generic;
using Runner.GameVariables;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Runner.UI
{
    public class MoneyText : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private void Start()
        {
            GameDynamicData.GetInstance()
                .GetReactiveMoney()
                .Subscribe(x => _text.text = x.ToString());
        }

        [Inject]
        private void Init(TextMeshProUGUI text)
        {
            _text = text;
        }
    }
}
