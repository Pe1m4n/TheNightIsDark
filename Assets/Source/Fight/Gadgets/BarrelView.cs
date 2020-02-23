using Zenject;

namespace Fight.Gadgets
{
    public class BarrelView : GadgetView
    {
        public BarrelData Data { get; set; }
        
        [Inject]
        public void SetUp(BarrelData data)
        {
            Data = data;
        }
    }
}