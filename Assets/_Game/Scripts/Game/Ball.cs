using Assets._Game.Scripts.InputLogic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Game.Scripts.Game
{
    public class Ball : MonoBehaviour
    {
        public event UnityAction BallMoved;
        [SerializeField] private MobileInputService gameInput;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float force;
        [SerializeField] private float forceMultyplyer;
        [SerializeField] private float smoothX;
        [SerializeField] private float maxVelocity = 8;

        private bool _isCanMove = true;
        private Vector2 _inputDirection;
        public bool IsCanMove => _isCanMove;
        void Start()
        {
            gameInput.Swipe += MoveBall;
        }
        public void SetForce(float force)
        {
            this.force = force;
        }
        public void AddForceToMovingBall()
        {
            AddForce(_inputDirection);
        }

        private void MoveBall(Vector2 direction)
        {
            if (!_isCanMove)
            {
                return;
            }

            BallMoved?.Invoke();
            _isCanMove = false;

            _inputDirection = direction.normalized;

            AddForce(direction);
        }
        private void AddForce(Vector2 direction)
        {
            Vector3 velocity = new Vector3(direction.x * force * forceMultyplyer, 0, direction.y * force * forceMultyplyer);

            if (velocity.z > maxVelocity)
            {
                velocity.z = maxVelocity;
            }
            velocity.x *= smoothX;
            _rigidbody.linearVelocity = velocity;
        }
    }
}