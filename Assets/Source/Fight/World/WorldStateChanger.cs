using DG.Tweening;
using UI;

namespace Fight.World
{
    public class WorldStateChanger : IWorldStateListener
    {
        private readonly IlluminationController _illuminationController;
        private readonly TextComponent _textComponent;

        public WorldStateChanger(IlluminationController illuminationController, TextComponent textComponent)
        {
            _illuminationController = illuminationController;
            _textComponent = textComponent;
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

        public int NightCount { get; set; }  = 0;
    
        private void SetNight()
        {
            NightCount++;
            float intencity = 1f;
            DOTween.To(() => intencity, (v) =>
            {
                intencity = v;
                _illuminationController.SetIntencity(intencity);
            }, 0f, 3f).SetEase(Ease.InSine);
            _textComponent.ShowText($"Night #{NightCount}");
        }
    }
}