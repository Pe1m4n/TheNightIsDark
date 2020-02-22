using UniRx;
using Zenject;

namespace Fight.State
{
    public class ReactiveStateHolder : ITickable
    {
        private readonly FightState _state;
        public ReactiveProperty<FightState> ObservableState;
        
        public ReactiveStateHolder(FightState state)
        {
            _state = state;
            ObservableState = new ReactiveProperty<FightState>(state);
        }

        public void Tick()
        {
            ObservableState.SetValueAndForceNotify(_state);
        }
    }
}