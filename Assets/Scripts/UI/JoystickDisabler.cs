using System;
using System.Collections;
using System.Collections.Generic;
using Runner.StateMachine;
using UnityEngine;
using Zenject;

namespace Runner.UI
{
    public class JoystickDisabler : MonoBehaviour
    {
        private PlayerPaintState _paintState;

        private void Start()
        {
            _paintState.OnPlayerEnteredPaintState += PlayerPaintState_PlayerEnteredPaintStateHandler;
        }

        private void PlayerPaintState_PlayerEnteredPaintStateHandler(object sender, EventArgs e)
        {
            gameObject.SetActive(false);
        }

        [Inject]
        private void Init(PlayerPaintState paintState)
        {
            _paintState = paintState;
        }
    }
}
