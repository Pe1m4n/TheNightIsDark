using Common.InputSystem;
using Fight;
using UnityEngine;

namespace Controls
{
    public class ClickTapPlayerController : IPlayerInputController
    {
        private readonly IInputSystem _inputSystem;
        private readonly Vector2 _playerPosition;

        public ClickTapPlayerController(IInputSystem inputSystem, Vector2 playerPosition)
        {
            _inputSystem = inputSystem;
            _playerPosition = playerPosition;
        }
        
        public Vector2 GetLookDirection()
        {
            Vector2  mousePosition = _inputSystem.GetMousePosition();
            return mousePosition - _playerPosition;
        }

        public bool ShotKeyDown()
        {
            return _inputSystem.GetKeyDown(KeyCode.Mouse0);
        }
    }
}