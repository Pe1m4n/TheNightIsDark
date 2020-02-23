using Common.InputSystem;
using Fight.Gadgets;
using UnityEngine;
using Zenject;

namespace Fight
{
    public class BuildingCursorHolder : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _barrelSpriteRenderer;
        [SerializeField] private SpriteRenderer _mineSpriteRenderer;

        private IInputSystem _inputSystem;
        private DayBehaviour.DayState _dayState;
        [Inject]
        public void SetUp(IInputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }
        
        public bool BuildingAllowed { get; set; }

        private void Update()
        {
            var pos = _inputSystem.GetMousePosition();
            pos.z = -1;
            transform.position = pos;
            HandleBuildingColor();
        }

        public void SetBuildingState(DayBehaviour.DayState state)
        {
            _dayState = state;
            if (state == DayBehaviour.DayState.Common)
            {
                _barrelSpriteRenderer.enabled = false;
                _mineSpriteRenderer.enabled = false;
                return;
            }

            _barrelSpriteRenderer.enabled = state == DayBehaviour.DayState.BuildingBarrel;
            _mineSpriteRenderer.enabled = state == DayBehaviour.DayState.BuildingMine;
        }

        private void HandleBuildingColor()
        {
            var hits = Physics2D.OverlapCircleAll(_inputSystem.GetMousePosition(), 0.5f);
            if (hits == null)
            {
                BuildingAllowed = true;
                SetColor(Color.green);
            }

            foreach (var hit in hits)
            {
                var player = hit.GetComponent<PlayerView>();
                if (player != null)
                {
                    BuildingAllowed = false;
                    SetColor(Color.red);
                    return;
                }

                var gadget = hit.GetComponent<GadgetView>();
                if (gadget != null)
                {
                    BuildingAllowed = false;
                    SetColor(Color.red);
                }
            }
            
            BuildingAllowed = true;
            SetColor(Color.green);
        }

        private void SetColor(Color color)
        {
            _barrelSpriteRenderer.color = color;
            _mineSpriteRenderer.color = color;
        }
    }
}