using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runner.Painting
{
    public class Painter
    {
        private LayerMask _layerMask;
        private Paintable _paintable;
        private Painter(LayerMask layerMask, Paintable paintable)
        {
            _layerMask = layerMask;
            _paintable = paintable;
        }

        public void TryPaint()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
            {
                _paintable.Paint(hit.textureCoord);
            }
        }
    }
    public struct IntVector2
    {
        public int X;
        public int Y;
        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
