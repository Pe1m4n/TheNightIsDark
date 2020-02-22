using Fight.Shooting;

namespace Fight.State
{
    public class FightState
    {
        public FightState(PlayerState playerState)
        {
            PlayerState = playerState;
        }
        
        public PlayerState PlayerState { get; private set; }
    }
}