using Fight;
using UnityEngine;
using UnityEngine.UI;

namespace Controls
{
    public class MobileJoystickPlayerController : IPlayerInputController
    {
        private readonly Selectable _joystick;
        
        public Vector2 GetLookDirection()
        {
            return new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
        }

        public bool ShotKeyDown()
        {
            return SimpleInput.GetButtonDown("Fire");
        }
    }
}