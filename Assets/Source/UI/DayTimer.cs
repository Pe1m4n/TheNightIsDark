using System;
using Fight;
using Fight.World;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UnityEditor.ShaderGraph
{
    public class DayTimer : MonoBehaviour, IWorldStateListener
    {
        [SerializeField] private Text _timerText;
        private WorldController _worldController;

        public void OnWorldStateChanged(WorldState state)
        {
            gameObject.SetActive(state == WorldState.Day);
        }

        public void SetUp(WorldController worldController)
        {
            _worldController = worldController;
        }

        private void Update()
        {
            _timerText.text = TimeSpan.FromSeconds(_worldController.Timer).ToString("ss");
        }
    }
}