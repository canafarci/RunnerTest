using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.StateMachine
{
    public class StateChangeTrigger : MonoBehaviour
    {
        private CharacterStateMachine _stateMachine;
        [SerializeField] private LayerStateMap[] _layerStateMaps;
        private Dictionary<int, CharacterState> _layerToStateDict = new();
        private void Start()
        {
            foreach (LayerStateMap layerToStateMap in _layerStateMaps)
            {
                int layerValue = layerToStateMap.LayerValue;
                CharacterState state = layerToStateMap.State;
                _layerToStateDict[layerValue] = state;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            int layer = other.gameObject.layer;

            if (_layerToStateDict.ContainsKey(layer))
            {
                CharacterState state = _layerToStateDict[layer];
                _stateMachine.AnyStateChange(state);
            }
        }

        [Inject]
        private void Init(CharacterStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }

    [System.Serializable]
    public struct LayerStateMap
    {
        public readonly int LayerValue { get { return LayerToInt(_layer); } }
        public CharacterState State;
        [SerializeField] private LayerMask _layer;

        private readonly int LayerToInt(int bitmask)
        {
            int result = bitmask > 0 ? 0 : 31;
            while (bitmask > 1)
            {
                bitmask >>= 1;
                result++;
            }
            return result;
        }
    }
}
