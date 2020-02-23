using System.Collections.Generic;
using Fight.Enemies;
using UnityEngine;
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

        private void Update()
        {
            var hits = Physics2D.OverlapCircleAll(transform.position, Data.TriggerRadius);

            if (hits == null)
            {
                return;
            }

            foreach (var hit in hits)
            {
                var enemy = hit.GetComponent<EnemyView>();
                if (enemy != null)
                {
                    Explode();
                }
            }
        }
        
        protected override float GetRadius()
        {
            return Data.DamageRadius;
        }

        protected override int GetDamage()
        {
            return Data.AttackData.Attack;
        }
    }
}