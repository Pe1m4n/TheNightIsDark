using System.Collections.Generic;
using Fight.Enemies;
using Fight.World;
using UnityEngine;
using Zenject;

namespace Fight
{
    public class WorldController : ITickable
    {
        private readonly WorldState _worldState;

        public float Timer { get; private set; }
        public WorldState WorldState
        {
            get => _worldState;
            set
            {
                if (value == WorldState.Day)
                {
                    Timer = _dayNightData.DaySeconds;
                }
                else
                {
                    Timer = _dayNightData.NightSeconds;
                }

                foreach (var listener in _listeners)
                {
                    listener.OnWorldStateChanged(value);
                }
            }
        }

        private readonly IlluminationController _illuminationController;
        private readonly DayNightChangeData _dayNightData;
        private readonly IEnumerable<IWorldStateListener> _listeners;

        private WorldBehaviourStrategy _currentBehaviourStrategy;

        private WorldBehaviourStrategy CurrentBehaviourStrategy
        {
            get => _currentBehaviourStrategy;
            set
            {
                _currentBehaviourStrategy?.Finish();
                _currentBehaviourStrategy = value;
                _currentBehaviourStrategy?.Start();
            }
        }
        
        public WorldController(IlluminationController illuminationController, NightBehaviour nightBehaviour,
         DayNightChangeData dayNightData, IEnumerable<IWorldStateListener> listeners)
        {
            _illuminationController = illuminationController;
            _dayNightData = dayNightData;
            _listeners = listeners;
            CurrentBehaviourStrategy = nightBehaviour;
        }

        public void Tick()
        {
            Timer -= Time.deltaTime;
            CurrentBehaviourStrategy?.Update();
        }
    }
}