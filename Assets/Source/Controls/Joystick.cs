using Fight.World;
using UnityEngine;

namespace Controls
{
    public class Joystick : MonoBehaviour, IWorldStateListener
    {
        public void OnWorldStateChanged(WorldState state)
        {
            gameObject.SetActive(state == WorldState.Night);
        }
    }
}