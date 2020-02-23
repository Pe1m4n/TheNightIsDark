using DG.Tweening;
using Fight.State;
using UI;

namespace Fight.World
{
    public class WorldStateChanger : IWorldStateListener
    {
        private readonly IlluminationController _illuminationController;
        private readonly TextComponent _textComponent;
        private readonly FightState _fightState;

        public WorldStateChanger(IlluminationController illuminationController, TextComponent textComponent, FightState fightState)
        {
            _illuminationController = illuminationController;
            _textComponent = textComponent;
            _fightState = fightState;
        }
        
        public void OnWorldStateChanged(WorldState state)
        {
            switch (state)
            {
                case WorldState.Day:
                    SetDay();
                    break;
                case WorldState.Night:
                    SetNight();
                    break;
            }
        }

        private void SetDay()
        {
            float intencity = 0f;
            DOTween.To(() => intencity, (v) =>
            {
                intencity = v;
                _illuminationController.SetIntencity(intencity);
            }, 1f, 3f).SetEase(Ease.InSine);
            _textComponent.ShowText("Prepare for the next night!");
        }
        
        private void SetNight()
        {
            _fightState.NightId++;
            if (_fightState.NightId != 1)
            {
                float intencity = 1f;
                DOTween.To(() => intencity, (v) =>
                {
                    intencity = v;
                    _illuminationController.SetIntencity(intencity);
                }, 0f, 3f).SetEase(Ease.InSine);
            }
            else
            {
                _illuminationController.SetIntencity(0f);
            }
            _textComponent.ShowText($"Night #{_fightState.NightId}");
        }
    }
}