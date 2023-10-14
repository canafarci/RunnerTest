using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner.State
{
    public class PlayerWaitForStartState : WaitState
    {
        //Initialization
        [Inject]
        private void Init([Inject(Id = BindingID.PlayerMoveState)] IState nextState)
        {
            _waitDuration = 3f;
            _nextState = nextState;
        }
    }
}
