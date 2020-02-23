using Zenject;

namespace Fight.Gadgets
{
    public class MineView : GadgetView
    {
        public MineData Data { get; set; }
        [Inject]
        public void SetUp(MineData data)
        {
            Data = data;
        }
    }
}