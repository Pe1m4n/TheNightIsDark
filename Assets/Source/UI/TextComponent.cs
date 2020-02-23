using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TextComponent : MonoBehaviour
    {
        [SerializeField] public Text text;
        [SerializeField] public CanvasGroup canvasGroup;

        public void ShowText(string message)
        {
            text.text = message;
            var alpha = 0f;
            var sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(() => alpha, x => canvasGroup.alpha = alpha = x, 1f, 1f));
            sequence.Append(DOTween.To(() => alpha, x => canvasGroup.alpha = alpha = x, 0f, 1f));
        }
    }
}