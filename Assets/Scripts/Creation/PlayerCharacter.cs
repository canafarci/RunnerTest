using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.Creation
{
    public class PlayerCharacter
    {
        public Transform Transform { get; private set; }

        private PlayerCharacter(Transform transform)
        {
            Transform = transform;
        }

        public class Factory : PlaceholderFactory<PlayerCharacter>
        {
        }
    }
}
