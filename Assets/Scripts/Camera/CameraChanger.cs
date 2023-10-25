using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Runner.StateMachine;
using System;
using Zenject;

namespace Runner.Camera
{
    public class CameraChanger : IInitializable
    {
        private CinemachineVirtualCamera _playCamera;
        private CinemachineVirtualCamera _paintCamera;
        private CameraChanger([Inject(Id = CameraID.PlayCamera)] CinemachineVirtualCamera playCamera,
                              [Inject(Id = CameraID.PaintCamera)] CinemachineVirtualCamera paintCamera
                              )
        {
            _playCamera = playCamera;
            _paintCamera = paintCamera;
        }

        public void Initialize()
        {
            PlayerPaintState.OnPlayerEnteredPaintState += PlayerPaintState_PlayerEnteredPaintStateHandler;
        }

        private void PlayerPaintState_PlayerEnteredPaintStateHandler(object sender, EventArgs e)
        {
            _playCamera.Priority = 0;
            _paintCamera.Priority = 10;
        }
    }

    public enum CameraID
    {
        PlayCamera,
        PaintCamera
    }
}
