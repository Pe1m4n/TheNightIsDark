using System.Collections.Generic;
using Fight.Enemies;
using UnityEngine;
using UnityEngine.Events;

namespace Fight.Gadgets
{
    public abstract class GadgetView : MonoBehaviour
    {
        private Animator _animator;
        public bool Exploded { get; set; }
        public UnityEvent OnExplode;
        private object _unitView;

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void Explode()
        {
            _animator.SetBool("Explode", true);
            HitAround();
            OnExplode.Invoke();
            Exploded = true;
        }

        private void HitAround()
        {
            var hits = Physics2D.OverlapCircleAll(transform.position, GetRadius());

            if (hits == null)
            {
                return;
            }

            var unitsToDamage = new List<EnemyView>();
            foreach (var hit in hits)
            {
                var enemy = hit.GetComponent<EnemyView>();
                if (enemy == null)
                {
                    continue;
                }
                unitsToDamage.Add(enemy);
            }

            foreach (var unit in unitsToDamage)
            {
                unit.HealthState.DealDamage(GetDamage());
            }
        }

        public object UnitView
        {
            get { return _unitView; }
            set { _unitView = value; }
        }

        protected abstract float GetRadius();

        protected abstract int GetDamage();
    }
}