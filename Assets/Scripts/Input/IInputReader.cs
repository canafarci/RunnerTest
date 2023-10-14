using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Input
{
    public interface IInputReader
    {
        public Vector2 GetInput();
    }
}