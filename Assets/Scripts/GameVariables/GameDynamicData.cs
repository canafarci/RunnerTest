using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Runner.GameVariables
{
    public class GameDynamicData
    {
        private readonly ReactiveProperty<int> _money = new();
        private int _deathCount;
        private static GameDynamicData _instance;

        public static GameDynamicData GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameDynamicData();
            }
            return _instance;
        }

        public void IncreaseMoney(int money)
        {
            _money.Value += money;
        }

        public ReactiveProperty<int> GetReactiveMoney() => _money;
    }
}
