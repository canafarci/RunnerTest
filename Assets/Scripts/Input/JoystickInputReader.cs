using UnityEngine;
using Zenject;

namespace Runner.Input
{
    public class JoystickInputReader : IInputReader
    {
        private Joystick _joystick;

        [Inject]
        private void Init(Joystick joystick)
        {
            _joystick = joystick;
        }
        public Vector2 GetInput()
        {
            return _joystick.Direction;
        }

    }
}
