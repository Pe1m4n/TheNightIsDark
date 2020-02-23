using System.Collections.Generic;
using Fight.Enemies;
using Fight.State;
using Fight.World;
using UnityEngine;
using Zenject;

namespace Fight
{
    public class WorldController : ITickable
    {
        private WorldState _worldState;

        public float Timer { get; private set; }
        public WorldState WorldState
        {
            get => _worldState;
            set
            {
                if (value == WorldState.Day)
                {
                    Timer = _dayNightData.DaySeconds;
                    CurrentBehaviourStrategy = null;
                }
                else
                {
                    Timer = _dayNightData.NightSeconds;
                    CurrentBehaviourStrategy = _nightBehaviour;
                }

                foreach (var listener in _listeners)
                {
                    listener.OnWorldStateChanged(value);
                }

                _worldState = value;
            }
        }

        private readonly IlluminationController _illuminationController;
        private readonly DayNightChangeData _dayNightData;
        private readonly IEnumerable<IWorldStateListener> _listeners;
        private readonly FightState _state;
        private NightBehaviour _nightBehaviour;
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
         DayNightChangeData dayNightData, IEnumerable<IWorldStateListener> listeners, FightState state)
        {
            _illuminationController = illuminationController;
            _dayNightData = dayNightData;
            _listeners = listeners;
            _state = state;
            CurrentBehaviourStrategy = nightBehaviour;
            _nightBehaviour = nightBehaviour;
        }

        public void Tick()
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0 && _state.Enemies.Count == EnemyView.EnemiesDead)
            {
                if (WorldState == WorldState.Day)
                {
                    WorldState = WorldState.Night;
                }
                else
                {
                    WorldState = WorldState.Day;
                }
            }
            CurrentBehaviourStrategy?.Update();
        }
    }
}