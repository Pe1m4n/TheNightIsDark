using Fight.State;
using UnityEngine;
using Zenject;

namespace Fight.Gadgets
{
    public class GadgetButtonsHolder : MonoBehaviour
    {
        private DayBehaviour _dayBehaviour;
        private PlayerState _playerState;
        
        [Inject]
        public void SetUp(DayBehaviour dayBehaviour, PlayerState playerState)
        {
            _dayBehaviour = dayBehaviour;
            _playerState = playerState;
        }

        public void TrySetBuildBarrel()
        {
            if (_playerState.InventoryState.BarrelCount <= 0)
            {
                return;
            }
            _dayBehaviour.State = DayBehaviour.DayState.BuildingBarrel;
        }

        public void TrySetBuildMine()
        {
            if (_playerState.InventoryState.MineCount <= 0)
            {
                return;
            }
            _dayBehaviour.State = DayBehaviour.DayState.BuildingMine;
        }
    }
}