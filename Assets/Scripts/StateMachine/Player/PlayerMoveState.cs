using UnityEngine;
using Zenject;
using Runner.PlayerMovement;

namespace Runner.StateMachine
{
    public class PlayerMoveState : IState
    {
        private readonly PlayerMover _playerMover;

        private PlayerMoveState(PlayerMover mover)
        {
            _playerMover = mover;
        }

        public void Enter()
        {

        }

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState; // this state can only be exited from an any transition from statemachine

            _playerMover.Move();

            return nextState;
        }

        public void Exit()
        {

        }
    }
}
