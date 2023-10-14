using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.State
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public IState Tick();
    }
}
