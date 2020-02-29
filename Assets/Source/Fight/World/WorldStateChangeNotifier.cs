using System;
using UnityEngine;
using UnityEngine.Events;

namespace Fight.World
{
    public class WorldStateChangeNotifier : MonoBehaviour, IWorldStateListener
    {
        public UnityEvent OnDayStart;
        public UnityEvent OnNightStart;
            
        public void OnWorldStateChanged(WorldState state)
        {
            switch (state)
            {
                case WorldState.Day:
                    OnDayStart.Invoke();
                    break;
                case WorldState.Night:
                    OnNightStart.Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}