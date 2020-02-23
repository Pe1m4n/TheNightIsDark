namespace Fight.World
{
    public interface IWorldStateListener
    {
        void OnWorldStateChanged(WorldState state);
    }
}