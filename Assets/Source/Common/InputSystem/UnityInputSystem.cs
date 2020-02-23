using UnityEngine;

namespace Common.InputSystem
{
    public class UnityInputSystem : IInputSystem
    {
        private readonly Camera _camera;

        public UnityInputSystem(Camera camera)
        {
            _camera = camera;
        }
        
        public Vector3 GetMousePosition()
        {
            var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -1f;
            return pos;
        }

        public bool GetKeyDown(KeyCode keyCode)
        {
            return Input.GetKeyDown(keyCode);
        }
    }
}