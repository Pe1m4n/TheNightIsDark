namespace Fight.State
{
    public abstract class EnemyBehaviour
    {
        public abstract void OnStart();
        public abstract void Update();

        public abstract void OnFinish();
    }
}