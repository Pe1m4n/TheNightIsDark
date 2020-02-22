using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Fight.World
{
    public class IlluminationController : MonoBehaviour
    {
        [SerializeField] private Light2D _globalLight;

        public void SetIntencity(float value)
        {
            _globalLight.intensity = value;
        }
    }
}