using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.Painting
{
    public class PaintingModel : IInitializable
    {
        private readonly Material _paintMaterial;
        private RenderTexture _paintableTexture;
        private readonly IntVector2 _textureSize = new IntVector2(1024, 512);
        private Color _red = new Color(1, 0, 0, 1);
        private Color _yellow = new Color(1, 1, 0, 1);
        private Color _blue = new Color(0, 0, 1, 1);
        public event EventHandler<PaintModelInitializedArgs> OnPaintModelInitialized;
        public event EventHandler<PaintingColorChangedArgs> OnPaintingColorChanged;
        public event EventHandler<PaintingBrushSizeChangedArgs> OnPaintingBrushSizeChanged;

        private PaintingModel(Material paintMaterial)
        {
            _paintMaterial = paintMaterial;
        }
        public void OnPaintColorChanged(ButtonColor buttonColor)
        {
            Color32 color = buttonColor switch
            {
                ButtonColor.Yellow => _yellow,
                ButtonColor.Blue => _blue,
                _ => _red,
            };

            InvokeColorChangedEvent(color);
        }

        public void OnBrushSizeChanged(float size)
        {
            InvokeBrushSizeChangedEvent(size);
        }

        private void InvokeBrushSizeChangedEvent(float size)
        {
            OnPaintingBrushSizeChanged?.Invoke(this, new PaintingBrushSizeChangedArgs
            {
                BrushSize = size,
            });
        }

        private void InvokeColorChangedEvent(Color color)
        {
            OnPaintingColorChanged?.Invoke(this, new PaintingColorChangedArgs
            {
                Color = color,
            });
        }

        public void Initialize()
        {
            CreateRenderTexture();
            ConvertRenderTextureToWhite();
            InvokeModelInitializedEvent();
            InvokeColorChangedEvent(_yellow);

            float initialBrushSize = 30f;
            InvokeBrushSizeChangedEvent(initialBrushSize);
        }

        private void InvokeModelInitializedEvent()
        {
            OnPaintModelInitialized?.Invoke(this, new PaintModelInitializedArgs
            {
                RenderTexture = _paintableTexture,
                TextureSize = _textureSize
            });
        }

        private void CreateRenderTexture()
        {
            _paintableTexture = new RenderTexture(_textureSize.X, _textureSize.Y, 0, RenderTextureFormat.ARGB32);
            _paintableTexture.enableRandomWrite = true;
            _paintableTexture.Create();

            _paintMaterial.SetTexture("_BaseMap", _paintableTexture);
        }

        private void ConvertRenderTextureToWhite()
        {
            RenderTexture.active = _paintableTexture;
            GL.Clear(true, true, Color.white);
            RenderTexture.active = null;
        }
    }
    public class PaintingBrushSizeChangedArgs
    {
        public float BrushSize;
    }
    public class PaintingColorChangedArgs
    {
        public Color Color;
    }
    public class PaintModelInitializedArgs : EventArgs
    {
        public RenderTexture RenderTexture;
        public IntVector2 TextureSize;
    }
}
