using System;
using System.Collections;
using Runner.StateMachine;
using UnityEngine;
using Zenject;

namespace Runner.Visuals
{
    public class CharacterDeathVisual : MonoBehaviour
    {
        private IRestartable _restartable;
        [SerializeField] private GameObject _characterVisual;
        private const float RESTART_DELAY = 2.2f;

        [Inject]
        private void Init(IRestartable restartable)
        {
            _restartable = restartable;
        }

        private void Start()
        {
            _restartable.OnCharacterRestart += RestartState_PlayerRestartHandler;
            gameObject.SetActive(false);
        }

        private void RestartState_PlayerRestartHandler(object sender, EventArgs e)
        {
            gameObject.SetActive(true);
            _characterVisual.SetActive(false);
            StartCoroutine(EnableModelAfterDelay());
        }

        private IEnumerator EnableModelAfterDelay()
        {
            yield return new WaitForSeconds(RESTART_DELAY);
            _characterVisual.SetActive(true);
            gameObject.SetActive(false);
        }


    }
}
