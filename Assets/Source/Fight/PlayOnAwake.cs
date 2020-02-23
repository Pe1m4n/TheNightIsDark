using UnityEngine;
using UnityEngine.Events;

namespace Fight
{
    public class PlayOnAwake : MonoBehaviour
    {
        public UnityAction action;

        private void Awake()
        {
            action?.Invoke();
        }
    }
}