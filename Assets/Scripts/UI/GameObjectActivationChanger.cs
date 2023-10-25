using System;
using System.Collections;
using System.Collections.Generic;
using Runner.StateMachine;
using UnityEngine;
using Zenject;

namespace Runner.UI
{
    public class GameObjectActivationChanger : MonoBehaviour
    {
        [SerializeField] private bool _disableOnStart;

        private void Start()
        {
            PlayerPaintState.OnPlayerEnteredPaintState += PlayerPaintState_PlayerEnteredPaintStateHandler;
            gameObject.SetActive(!_disableOnStart);
        }

        private void PlayerPaintState_PlayerEnteredPaintStateHandler(object sender, EventArgs e)
        {
            bool isActive = gameObject.activeSelf;
            gameObject.SetActive(!isActive);
        }
    }
}
