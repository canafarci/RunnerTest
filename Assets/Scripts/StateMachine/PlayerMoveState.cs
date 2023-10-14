using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.State
{
    public class PlayerMoveState : MonoBehaviour, IState
    {
        public void Enter()
        {

        }

        public IState Tick()
        {
            IState nextState = null;
            print("moving");
            return nextState;
        }

        public void Exit()
        {

        }
    }
}
