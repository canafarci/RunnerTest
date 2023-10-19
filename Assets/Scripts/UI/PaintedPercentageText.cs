using TMPro;
using UnityEngine;
using Zenject;
using Runner.Painting;
using UniRx;

namespace Runner.UI
{
    public class PaintedPercentageText : MonoBehaviour
    {
        private PixelChecker _pixelCalculator;
        private TextMeshProUGUI _text;

        private void Start()
        {
            _pixelCalculator.GetReactivePercentage().Subscribe(x => _text.text = $"%{x}");
        }

        [Inject]
        private void Init(PixelChecker pixelCalculator, TextMeshProUGUI text)
        {
            _pixelCalculator = pixelCalculator;
            _text = text;
        }
    }
}
