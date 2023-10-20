using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace Runner.Painting
{
    public class PixelChecker : IInitializable, IDisposable
    {
        private ComputeShader _checkAllPaintedPixelsShader;
        private PaintingModel _paintingModel;
        private RenderTexture _paintableTexture;
        private CompositeDisposable _disposables = new CompositeDisposable();
        private ReactiveProperty<int> _percentagePainted = new ReactiveProperty<int>();

        private PixelChecker(PaintingModel model,
                             [Inject(Id = ComputeShaders.CheckPixelsShader)] ComputeShader checkPixelShader)
        {
            _checkAllPaintedPixelsShader = checkPixelShader;
            _paintingModel = model;
        }

        public void Initialize()
        {
            _paintingModel.OnPaintModelInitialized += PaintingModel_PaintModelInitializedHandler;

            CreateDataStream();
        }

        private void CreateDataStream()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(500)).Subscribe(x => CheckPixels()).AddTo(_disposables);
        }

        private void PaintingModel_PaintModelInitializedHandler(object sender, PaintModelInitializedArgs e)
        {
            _paintableTexture = e.RenderTexture;
            _checkAllPaintedPixelsShader.SetTexture(0, "InputTex", _paintableTexture);
        }

        public void CheckPixels()
        {
            int size = _paintableTexture.width * _paintableTexture.height;
            int[] paintedPixels = new int[size];

            UpdatePaintedPixelArray(size, paintedPixels);
            float percentage = CalculatePercentagePainted(size, paintedPixels);

            _percentagePainted.Value = (int)percentage;
        }

        private float CalculatePercentagePainted(int size, int[] paintedPixels)
        {
            int sum = 0;
            for (int i = 0; i < paintedPixels.Length; i++)
            {
                sum += paintedPixels[i];
            }

            float percentage = sum / (float)size;
            percentage *= 100f;
            return percentage;
        }

        private void UpdatePaintedPixelArray(int size, int[] paintedPixels)
        {
            ComputeBuffer buffer = new ComputeBuffer(size, sizeof(int));
            buffer.SetData(paintedPixels);

            _checkAllPaintedPixelsShader.SetBuffer(0, "PaintedPixelArray", buffer);
            _checkAllPaintedPixelsShader.Dispatch(0, _paintableTexture.width / 8, _paintableTexture.height / 4, 1);

            buffer.GetData(paintedPixels);
            buffer.Dispose();
        }
        //Getters-Setters
        public ReactiveProperty<int> GetReactivePercentage() => _percentagePainted;

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
