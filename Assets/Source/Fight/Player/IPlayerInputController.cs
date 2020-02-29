using UnityEngine;

namespace Fight
{
    public interface IPlayerInputController
    {
        Vector2 GetLookDirection();

        bool ShotKeyDown();
    }
}