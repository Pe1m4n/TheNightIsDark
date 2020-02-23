using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Fight.Enemies;
using Fight.State;
using Fight.World;
using UI;
using UnityEditor.ShaderGraph;
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
                    CurrentBehaviourStrategy = _dayBehaviour;
                }
                else
                {
                    Timer = _dayNightData.NightSeconds;
                    CurrentBehaviourStrategy = _nightBehaviour;
                }

                foreach (var listener in _listeners)
                {
                    if (listener == null)
                    {
                        continue;
                    }
                    listener.OnWorldStateChanged(value);
                }

                _worldState = value;
                _state.WorldState = value;
            }
        }

        private readonly IlluminationController _illuminationController;
        private readonly DayNightChangeData _dayNightData;
        private readonly IEnumerable<IWorldStateListener> _listeners;
        private readonly FightState _state;
        private readonly TextComponent _textComponent;
        private readonly DayBehaviour _dayBehaviour;
        private NightBehaviour _nightBehaviour;
        private WorldBehaviourStrategy _currentBehaviourStrategy;
        private bool DisaleSimulation { get; set; }

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
         DayNightChangeData dayNightData, IEnumerable<IWorldStateListener> listeners, FightState state,
         TextComponent textComponent, DayBehaviour dayBehaviour, DayTimer dayTimer)
        {
            _illuminationController = illuminationController;
            _dayNightData = dayNightData;
            _listeners = listeners;
            _state = state;
            _textComponent = textComponent;
            _dayBehaviour = dayBehaviour;
            CurrentBehaviourStrategy = nightBehaviour;
            _nightBehaviour = nightBehaviour;
            dayTimer.SetUp(this);
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                foreach (var enemy in _state.Enemies)
                {
                    enemy.HealthState.DealDamage(5000);
                }
            }
            
            if (DisaleSimulation)
            {
                return;
            }
            
            if (_state.PlayerState.HealthState.CurrentHealth <= 0)
            {
                GameOver();
                return;
            }
            Timer -= Time.deltaTime;
            if (Timer <= 0 && _state.Enemies.Count <= 0)
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

        private async void GameOver()
        {
            _textComponent.ShowText("Game over. Try again!");
            
            _state.Reset();
            _state.NightId++;
            Timer = _dayNightData.NightSeconds;
            _nightBehaviour.Finish();
            DisaleSimulation = true;
            await Task.Delay(TimeSpan.FromSeconds(3f));
            DisaleSimulation = false;
        }
    }
}