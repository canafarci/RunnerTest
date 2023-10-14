using UnityEngine;
using Zenject;
using Runner.PlayerMovement;

namespace Runner.State
{
    public class PlayerMoveState : IState
    {
        private PlayerMover _playerMover;

        public void Enter()
        {

        }

        public IState Tick()
        {
            IState nextState = null; // this state can only be exited from an any transition from statemachine

            _playerMover.Move();

            return nextState;
        }

        public void Exit()
        {

        }

        //initialization
        [Inject]
        private void Init(PlayerMover mover)
        {
            _playerMover = mover;
        }
    }
}
