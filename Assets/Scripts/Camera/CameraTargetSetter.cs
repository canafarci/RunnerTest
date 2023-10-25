using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Runner.Camera;
using Runner.Creation;
using UnityEngine;
using Zenject;

public class CameraTargetSetter
{
    private CinemachineVirtualCamera _cam;
    private CharacterSpawner _spawner;

    private CameraTargetSetter([Inject(Id = CameraID.PlayCamera)] CinemachineVirtualCamera cam,
                                CharacterSpawner spawner)
    {
        _cam = cam;
        _spawner = spawner;

        _spawner.OnPlayerSpawned += CharacterSpawner_PlayerSpawnedHandler;
    }

    private void CharacterSpawner_PlayerSpawnedHandler(Transform transform)
    {
        _cam.m_Follow = transform;
        UnityEngine.Debug.Log(_cam);
    }
}
