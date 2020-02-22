using Fight.Enemies;
using Fight.World;
using Zenject;

namespace Fight
{
    public class WorldController : ITickable
    {
        public WorldState WorldState { get; }
        private readonly IlluminationController _illuminationController;

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
        
        public WorldController(IlluminationController illuminationController, NightBehaviour nightBehaviour)
        {
            _illuminationController = illuminationController;
            CurrentBehaviourStrategy = nightBehaviour;
        }

        public void Tick()
        {
            CurrentBehaviourStrategy?.Update();
        }
    }
}