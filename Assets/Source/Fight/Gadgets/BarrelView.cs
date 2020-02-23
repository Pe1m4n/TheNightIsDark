using Fight.Enemies;
using Fight.Health;
using Fight.State;
using UnityEngine;
using Zenject;

namespace Fight.Gadgets
{
    [RequireComponent(typeof(Animator))]
    public class BarrelView : GadgetView, IBulletTarget
    {
        public BarrelData Data { get; set; }
        
        [Inject]
        public void SetUp(BarrelData data)
        {
            Data = data;
            HealthState = new HealthState(data.HealthData);
        }

        private void Update()
        {
            if (Exploded)
            {
                return;
            }

            if (HealthState.CurrentHealth <= 0)
            {
                Explode();
            }
        }

        public HealthState HealthState { get; set; }
    } 
}