using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.Painting
{
    public class Paintable : IInitializable
    {
        private ComputeShader _brushPaintingComputeShader;
        private PaintingModel _paintingModel;
        private IntVector2 _textureSize;

        public void Initialize()
        {
            _paintingModel.OnPaintModelInitialized += PaintingModel_PaintModelInitializedHandler;
            _paintingModel.OnPaintingColorChanged += PaintingModel_PaintingColorChangedHandler;
            _paintingModel.OnPaintingBrushSizeChanged += PaintingModel_PaintingBrushSizeChangeddHandler;
        }

        public void Paint(Vector2 inputCoordinates)
        {
            Vector2 uv = GetUVCoordinates(inputCoordinates);

            _brushPaintingComputeShader.SetVector("UV", uv);
            _brushPaintingComputeShader.Dispatch(0, _textureSize.X / 8, _textureSize.Y / 4, 1);
        }

        private void PaintingModel_PaintingBrushSizeChangeddHandler(object sender, PaintingBrushSizeChangedArgs e)
        {
            _brushPaintingComputeShader.SetFloat("brushSize", e.BrushSize);
        }

        private void PaintingModel_PaintingColorChangedHandler(object sender, PaintingColorChangedArgs e)
        {
            _brushPaintingComputeShader.SetVector("paintColor", (Vector4)e.Color);
        }

        private void PaintingModel_PaintModelInitializedHandler(object sender, PaintModelInitializedArgs e)
        {
            _textureSize = e.TextureSize;
            InitializeShader(e.RenderTexture);
        }

        private void InitializeShader(RenderTexture paintableTexture)
        {
            _brushPaintingComputeShader.SetTexture(0, "Result", paintableTexture);
        }

        private Vector2 GetUVCoordinates(Vector2 hitUV)
        {
            hitUV.x *= _textureSize.X;
            hitUV.y *= _textureSize.Y;
            return hitUV;
        }

        private Paintable(PaintingModel model,
                  [Inject(Id = ComputeShaders.PaintShader)] ComputeShader brushPaintingComputeShader)
        {
            _paintingModel = model;
            _brushPaintingComputeShader = brushPaintingComputeShader;
        }
    }
}
