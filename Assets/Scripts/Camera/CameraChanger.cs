using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Runner.StateMachine;
using System;
using Zenject;

namespace Runner.Camera
{
    public class CameraChanger : MonoBehaviour
    {
        private enum CameraID
        {
            PlayCamera,
            PaintCamera
        }
        private CinemachineVirtualCamera _camera;
        private PlayerPaintState _paintState;
        [SerializeField] private CameraID _cameraID;

        // private void Start()
        // {
        //     _paintState.OnPlayerEnteredPaintState += PlayerPaintState_PlayerEnteredPaintStateHandler;
        // }

        private void PlayerPaintState_PlayerEnteredPaintStateHandler(object sender, EventArgs e)
        {
            if (_cameraID == CameraID.PaintCamera)
            {
                _camera.Priority = 10;
            }
            else
            {
                _camera.Priority = 0;
            }
        }

        // [Inject]
        // private void Init(CinemachineVirtualCamera camera, PlayerPaintState paintState)
        // {
        //     _camera = camera;
        //     _paintState = paintState;

        // }

    }
}
