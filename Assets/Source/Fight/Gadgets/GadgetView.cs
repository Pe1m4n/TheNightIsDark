using UnityEngine;
using UnityEngine.Events;

namespace Fight.Gadgets
{
    public abstract class GadgetView : MonoBehaviour
    {
        private Animator _animator;
        public bool Exploded { get; set; }
        public UnityEvent OnExplode;
        
        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void Explode()
        {
            _animator.SetBool("Explode", true);
            OnExplode.Invoke();
            Exploded = true;
        }
    }
}