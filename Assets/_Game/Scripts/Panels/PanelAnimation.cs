using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._Game.Scripts.Panels
{
    public class PanelAnimation : MonoBehaviour
    {
        public event UnityAction PanelSwitchedOn;
        public event UnityAction PanelSwitchedOff;
        [SerializeField] private CanvasGroup group;
        [SerializeField] private RectTransform[] rectTransforms;
        [SerializeField] private float duration;
        [SerializeField] private Vector2 startScale = new Vector3(0.5f, 0.5f, 1f);
        [SerializeField] private float moveDownAmount;
        [SerializeField] private float moveDownDuration;
        [SerializeField] private Button closeButton;

        public Ease moveEaseType = Ease.OutBack;

        private Sequence[] sequences;
        private void Start()
        {
            if (closeButton != null)
                closeButton.onClick.AddListener(OnClose);
        }
        private void OnClose()
        {
            Switch(false);
        }
        public void Switch(bool isOn = true)
        {
            if (isOn)
            {
                sequences = new Sequence[rectTransforms.Length];
                PanelSwitchedOn?.Invoke();
            }
            else if (sequences == null)
            {
                return;
            }
            group.gameObject.SetActive(true);
            group.DOFade(isOn ? 1 : 0, duration).OnKill(() =>
            {
                if (!isOn)
                {
                    if (group != null)
                        group.gameObject?.SetActive(false);
                    PanelSwitchedOff?.Invoke();
                }
            });
            for (int i = 0; i < rectTransforms.Length; i++)
            {
                if (sequences[i] == null)
                {
                    sequences[i] = DOTween.Sequence();
                }
                Sequence sequence = sequences[i];
                if (isOn)
                {
                    RectTransform panelTransform = rectTransforms[i];
                    panelTransform.localScale = startScale;
                    sequence.Join(panelTransform.DOScale(1, duration));
                    sequence.Join(panelTransform.DOMoveY(panelTransform.position.y - moveDownAmount, moveDownDuration).SetEase(moveEaseType));
                    sequence.SetAutoKill(false);
                }
                else
                {
                    sequence.PlayBackwards();
                }
            }
        }
    }
}