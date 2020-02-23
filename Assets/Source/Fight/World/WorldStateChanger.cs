using DG.Tweening;

namespace Fight.World
{
    public class WorldStateChanger : IWorldStateListener
    {
        private readonly IlluminationController _illuminationController;

        public WorldStateChanger(IlluminationController illuminationController)
        {
            _illuminationController = illuminationController;
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
        }

        private void SetNight()
        {
            float intencity = 1f;
            DOTween.To(() => intencity, (v) =>
            {
                intencity = v;
                _illuminationController.SetIntencity(intencity);
            }, 0f, 3f).SetEase(Ease.InSine);
        }
    }
}