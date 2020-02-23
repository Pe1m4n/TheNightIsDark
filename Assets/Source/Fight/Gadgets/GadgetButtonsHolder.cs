using UnityEngine;
using Zenject;

namespace Fight.Gadgets
{
    public class GadgetButtonsHolder : MonoBehaviour
    {
        private DayBehaviour _dayBehaviour;
        
        [Inject]
        public void SetUp(DayBehaviour dayBehaviour)
        {
            _dayBehaviour = dayBehaviour;
        }

        public void TrySetBuildBarrel()
        {
            _dayBehaviour.State = DayBehaviour.DayState.BuildingBarrel;
        }

        public void TrySetBuildMine()
        {
            _dayBehaviour.State = DayBehaviour.DayState.BuildingMine;
        }
    }
}