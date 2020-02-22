using System.Collections.Generic;

namespace Fight.State
{
    public class FightState
    {
        public FightState(PlayerState playerState)
        {
            PlayerState = playerState;
        }
        
        public PlayerState PlayerState { get; private set; }
        public List<EnemyState> Enemies { get; } = new List<EnemyState>();
    }
}