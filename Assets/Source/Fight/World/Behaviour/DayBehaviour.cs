using Common.InputSystem;
using Fight.Gadgets;
using UnityEngine;

namespace Fight
{
    public class DayBehaviour : WorldBehaviourStrategy
    {
        private readonly BuildingCursorHolder _cursorHolder;
        private readonly GadgetFactory<BarrelData, BarrelView> _barrelFactory;
        private readonly GadgetFactory<MineData, MineView> _mineFactory;
        private readonly IInputSystem _inputSystem;
        private readonly BarrelData _barrelData;
        private readonly MineData _mineData;
        private DayState _state;

        public enum DayState
        {
            Common,
            BuildingBarrel,
            BuildingMine
        }

        public DayState State
        {
            get => _state;
            set
            {
                ProcessStateExit(_state);
                _state = value;
                _cursorHolder.SetBuildingState(_state);
                ProcessStateEnter(_state);
            }
        }

        public DayBehaviour(BuildingCursorHolder cursorHolder, GadgetFactory<BarrelData, BarrelView> barrelFactory,
            GadgetFactory<MineData, MineView> mineFactory, IInputSystem inputSystem, BarrelData barrelData, MineData mineData)
        {
            _cursorHolder = cursorHolder;
            _barrelFactory = barrelFactory;
            _mineFactory = mineFactory;
            _inputSystem = inputSystem;
            _barrelData = barrelData;
            _mineData = mineData;
        }

        public override void Start()
        {
            State = DayState.Common;
        }

        public override void Update()
        {
            if (State == DayState.Common)
            {
                return;
            }
            
            if (_inputSystem.GetKeyDown(KeyCode.Mouse1))
            {
                State = DayState.Common;
                return;
            }

            if (_inputSystem.GetKeyDown(KeyCode.Mouse0))
            {
                TryBuild(State);
            }
        }

        private void TryBuild(DayState state)
        {
            if (!_cursorHolder.BuildingAllowed)
            {
                return;
            }

            switch (state)
            {
                case DayState.BuildingBarrel:
                    _barrelFactory.Create(_barrelData, _inputSystem.GetMousePosition());
                    break;
                case DayState.BuildingMine:
                    _mineFactory.Create(_mineData, _inputSystem.GetMousePosition());
                    break;
            }

            State = DayState.Common;
        }

        public override void Finish()
        {
            State = DayState.Common;
        }

        private void ProcessStateExit(DayState state)
        {
        }

        private void ProcessStateEnter(DayState state)
        {
            
        }
    }
}