using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.Painting
{
    public class PaintingController : MonoBehaviour
    {
        private PaintingModel _paintingModel;

        public void OnYellowButtonClicked()
        {
            _paintingModel.OnPaintColorChanged(ButtonColor.Yellow);
        }
        public void OnBlueButtonClicked()
        {
            _paintingModel.OnPaintColorChanged(ButtonColor.Blue);
        }
        public void OnRedButtonClicked()
        {
            _paintingModel.OnPaintColorChanged(ButtonColor.Red);
        }
        public void OnSliderValueChanged(float value)
        {
            _paintingModel.OnBrushSizeChanged(value);
        }

        [Inject]
        private void Init(PaintingModel model)
        {
            _paintingModel = model;
        }
    }
}
