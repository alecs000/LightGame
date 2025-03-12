using Assets._Game.Scripts.Game;
using Assets._Game.Scripts.Panels;
using UnityEngine;

namespace Assets._Game.Scripts.Shop
{
    public class OpenShopExecutor : MonoBehaviour
    {
        [SerializeField] private PanelAnimation panelAnimation;
        [SerializeField] private RayByClickDrawer rayByClickDrawer;
        [SerializeField] private Collider colliderForOpen;

        private void Start()
        {
            rayByClickDrawer.RayCollide += OnClick;
            panelAnimation.PanelSwitchedOff += () => colliderForOpen.enabled = true;
            panelAnimation.PanelSwitchedOn += () => colliderForOpen.enabled = false;
        }
        private void OnDestroy()
        {
            rayByClickDrawer.RayCollide -= OnClick;
        }
        void OnClick(RaycastHit raycastHit)
        {
            if (raycastHit.transform.gameObject == gameObject)
            {
                OnShopClick();
            }
        }

        private void OnShopClick()
        {
            panelAnimation.Switch();
        }
    }
}