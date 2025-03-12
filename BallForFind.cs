using Assets._Game.Scripts.Game;
using UnityEngine;
using UnityEngine.Events;

public class BallForFind : MonoBehaviour
{
    public event UnityAction Clicked;
    [SerializeField] private RayByClickDrawer rayByClickDrawer;
    private void Start()
    {
        rayByClickDrawer.RayCollide += OnClick;
    }
    private void OnDestroy()
    {
        rayByClickDrawer.RayCollide -= OnClick;
    }
    void OnClick(RaycastHit raycastHit)
    {
            if (raycastHit.transform.gameObject == gameObject)
            {
                OnBallClicked();
            }
    }
    private void OnBallClicked()
    {
        Clicked?.Invoke();
        Destroy(gameObject);
    }
}
