using UnityEngine;
using UnityEngine.Events;

namespace Assets._Game.Scripts.InputLogic
{
    public class MobileInputService : MonoBehaviour, IInputService
    {
        public event UnityAction<Vector2> Swipe;
        public event UnityAction<Vector2> Click;

        [SerializeField] private float minimum;
        private Vector2 startDragPosition;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    startDragPosition = touch.position;
                    Click?.Invoke(startDragPosition);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Vector2 screenSize = new Vector2(Screen.width, Screen.height);
                    Vector2 normalizedTouchPosition = new Vector2(touch.position.x / screenSize.x, touch.position.y / screenSize.y);
                    Vector2 normalizedStartDragPosition = new Vector2(startDragPosition.x / screenSize.x, startDragPosition.y / screenSize.y);

                    Vector2 direction = normalizedTouchPosition - normalizedStartDragPosition;
                    if (direction.magnitude < minimum)
                        return;
                    Swipe?.Invoke(direction);
                }
            }
        }
    }
}