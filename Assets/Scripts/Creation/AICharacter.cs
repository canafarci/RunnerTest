using System.Collections;
using System.Collections.Generic;
using Runner.Containers;
using UnityEngine;
using Zenject;

namespace Runner.Creation
{
    public class AICharacter
    {
        public Transform Transform { get; private set; }

        private AICharacter(Transform transform)
        {
            Transform = transform;
        }

        public class Factory : PlaceholderFactory<AICharacter>
        {
        }
    }
}
