using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.StateMachine;

namespace Runner.Obstacles
{
    public class RestartTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<CharacterStateMachine>().ChangeStateToResetState();
        }
    }
}
