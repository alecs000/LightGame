using UnityEngine;
using UnityEngine.Events;

namespace Assets._Game.Scripts.InputLogic
{
    public class PCInputService : MonoBehaviour, IInputService
    {
        public event UnityAction<Vector2> Swipe;
        public event UnityAction<Vector2> Click;

        [SerializeField] private float minimum;
        private Vector2 startDragPosition;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                startDragPosition = Input.mousePosition;
                Click?.Invoke(startDragPosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 screenSize = new Vector2(Screen.width, Screen.height);
                Vector2 normalizedMousePosition = new Vector2(Input.mousePosition.x / screenSize.x, Input.mousePosition.y / screenSize.y);
                Vector2 normalizedStartDragPosition = new Vector2(startDragPosition.x / screenSize.x, startDragPosition.y / screenSize.y);

                Vector2 direction = normalizedMousePosition - normalizedStartDragPosition;
                if (direction.magnitude < minimum)
                    return;
                Swipe?.Invoke(direction);
            }
        }

    }
}