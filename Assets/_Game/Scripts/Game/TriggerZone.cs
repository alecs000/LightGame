using UnityEngine;
using UnityEngine.Events;

namespace Assets._Game.Scripts.Game
{
    public class TriggerZone : MonoBehaviour
    {
        public event UnityAction Triggered;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Ball ball))
            {
                Triggered?.Invoke();
            }
        }
    }
}