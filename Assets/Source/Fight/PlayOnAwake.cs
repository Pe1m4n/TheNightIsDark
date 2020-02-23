using UnityEngine;
using UnityEngine.Events;

namespace Fight
{
    public class PlayOnAwake : MonoBehaviour
    {
        [SerializeField] public UnityEvent action;

        private void Awake()
        {
            action?.Invoke();
        }
    }
}