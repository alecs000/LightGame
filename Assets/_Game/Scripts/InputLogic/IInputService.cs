using UnityEngine;
using UnityEngine.Events;

namespace Assets._Game.Scripts.InputLogic
{
    public interface IInputService
    {
        public event UnityAction<Vector2> Swipe;
        public event UnityAction<Vector2> Click;
    }
}