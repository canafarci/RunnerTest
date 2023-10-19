using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.Painting
{
    public class PixelChecker : IInitializable
    {
        private ComputeShader _checkAllPaintedPixelsShader;
        private PaintingModel _paintingModel;
        private RenderTexture _paintableTexture;

        private PixelChecker(PaintingModel model,
                             [Inject(Id = ComputeShaders.CheckPixelsShader)] ComputeShader checkPixelShader)
        {
            _checkAllPaintedPixelsShader = checkPixelShader;
            _paintingModel = model;
        }

        public void Initialize()
        {
            _paintingModel.OnPaintModelInitialized += PaintingModel_PaintModelInitializedHandler;
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


            ComputeBuffer buffer = new ComputeBuffer(size, sizeof(int));
            buffer.SetData(paintedPixels);
            _checkAllPaintedPixelsShader.SetBuffer(0, "PaintedPixelArray", buffer);
            _checkAllPaintedPixelsShader.Dispatch(0, _paintableTexture.width / 8, _paintableTexture.height / 4, 1);
            buffer.GetData(paintedPixels);
            buffer.Dispose();

            int sum = 0;
            for (int i = 0; i < paintedPixels.Length; i++)
            {
                sum += paintedPixels[i];
            }
        }


    }
}
