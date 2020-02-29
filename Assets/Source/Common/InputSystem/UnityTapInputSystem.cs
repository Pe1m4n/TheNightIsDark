using UnityEngine;

namespace Common.InputSystem
{
    public class UnityTapInputSystem : IInputSystem
    {
        private readonly Camera _camera;
        private Vector3 _lastTapPosition;

        public UnityTapInputSystem(Camera camera)
        {
            _camera = camera;
        }
        
        
        public Vector3 GetMousePosition()
        {
            if (Input.touchCount <= 0)
            {
                return _lastTapPosition;
            }
            _lastTapPosition = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
            _lastTapPosition.z = -1f;
            
            return _lastTapPosition;
        }

        public bool GetKeyDown(KeyCode keyCode)
        {
            if (keyCode != KeyCode.Mouse0)
            {
                return Input.GetKeyDown(keyCode);
            }
            
            if (Input.touchCount <= 0)
            {
                return false;
            }

            var touch = Input.GetTouch(0);
            
            return touch.phase == TouchPhase.Began;
        }
    }
}