using UnityEngine;

namespace Fight
{
    public class SelfDestructionComponent : MonoBehaviour
    {
        public float destroyAfterSeconds;
        private float _destroyTime;
        private void Start()
        {
            _destroyTime = Time.time + destroyAfterSeconds;
        }

        private void Update()
        {
            if (Time.time >= _destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}