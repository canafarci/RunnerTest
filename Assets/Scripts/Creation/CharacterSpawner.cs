using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.Creation
{
    public class CharacterSpawner : IInitializable
    {
        private readonly AICharacter.Factory _aiFactory;
        private readonly PlayerCharacter.Factory _playerFactory;
        private readonly Transform[] _spawnPositions;
        private readonly Transform _playerSpawnPosition;

        public event Action<Transform> OnPlayerSpawned;

        private CharacterSpawner(PlayerCharacter.Factory playerFactory,
                                 AICharacter.Factory aiFactory,
                                 Transform[] spawnPositions)
        {
            _aiFactory = aiFactory;
            _spawnPositions = spawnPositions;
            _playerFactory = playerFactory;
        }

        public void Initialize()
        {
            foreach (Transform tr in _spawnPositions)
            {
                AICharacter character = _aiFactory.Create();
                character.Transform.parent = tr;
                character.Transform.localPosition = Vector3.zero;
            }

            PlayerCharacter playerCharacter = _playerFactory.Create();
            playerCharacter.Transform.parent = _playerSpawnPosition;
            playerCharacter.Transform.localPosition = Vector3.zero;

            OnPlayerSpawned?.Invoke(playerCharacter.Transform);
        }
    }
}
