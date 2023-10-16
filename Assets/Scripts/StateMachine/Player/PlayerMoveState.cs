using UnityEngine;
using Zenject;
using Runner.Movement;
using Runner.Input;

namespace Runner.StateMachine
{
    public class PlayerMoveState : IState
    {
        private readonly IMoveable _playerMover;
        private readonly IInputReader _inputReader;

        private PlayerMoveState([Inject(Id = MovementComponents.PlayerCharacterController)] IMoveable mover,
                                IInputReader reader)
        {
            _playerMover = mover;
            _inputReader = reader;
        }

        public void Enter()
        {

        }

        public CharacterState Tick()
        {
            CharacterState nextState = CharacterState.StayInState; // this state can only be exited from an any transition from statemachine
            Vector2 input = _inputReader.GetInput();

            _playerMover.TickMovement(input);

            return nextState;
        }

        public void Exit()
        {

        }
    }
}
