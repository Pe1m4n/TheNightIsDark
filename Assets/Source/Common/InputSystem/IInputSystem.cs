using UnityEngine;

namespace Common.InputSystem
{
    public interface IInputSystem
    {
        Vector3 GetMousePosition();
        bool GetKeyDown(KeyCode keyCode);
    }
}