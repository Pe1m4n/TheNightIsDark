using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Fight
{
    public class LightFlashAnimation : MonoBehaviour
    {
        private Light2D _light;
        [SerializeField] private float _lightDuration;
        [SerializeField] private float _intencity;
        private Sequence _currentSequence;
        private void Awake()
        {
            _light = GetComponent<Light2D>();
        }

        public void Flash()
        {
            _currentSequence?.Kill(true);

            _currentSequence = DOTween.Sequence();
            _currentSequence.Append(GetFlashTween(_intencity, Ease.Flash));
            _currentSequence.Append(GetFlashTween(0, Ease.Flash));
        }

        private TweenerCore<float, float, FloatOptions> GetFlashTween(float to, Ease ease)
        {
            float currentIntencity = 0f;
            return DOTween.To(() => currentIntencity, value => currentIntencity = value,
                to, _lightDuration).OnUpdate(() => _light.intensity = currentIntencity).SetEase(ease);
        }
    }
}