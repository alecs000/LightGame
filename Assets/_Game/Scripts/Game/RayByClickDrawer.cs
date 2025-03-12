using Assets._Game.Scripts.InputLogic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Game.Scripts.Game
{
    public class RayByClickDrawer : MonoBehaviour
    {
        public event UnityAction<RaycastHit> RayCollide;
        [SerializeField] private LayerMask raycastLayer;
        [SerializeField] private int maxRayDistance;
        [SerializeField] private MobileInputService mobileInputService;
        private void Start()
        {
            mobileInputService.Click += OnClick;
        }
        private void OnDestroy()
        {
            mobileInputService.Click -= OnClick;
        }
        void OnClick(Vector2 diraction)
        {
            Ray ray = Camera.main.ScreenPointToRay(diraction);
            if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, raycastLayer))
            {
                RayCollide?.Invoke(hit);
            }
        }
    }
}