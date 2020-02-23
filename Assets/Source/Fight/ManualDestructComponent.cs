using UnityEngine;

namespace Fight
{
    public class ManualDestructComponent : MonoBehaviour
    {
        public void Destruct()
        {
            Destroy(gameObject);
        }
    }
}