using Assets._Game.Scripts.Game;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Game.Scripts.EndGame
{
    public class LoseChecker : MonoBehaviour
    {
        public event UnityAction EndGame;
        [SerializeField] private Rigidbody rigidbodyPlayer;
        [SerializeField] private float velocityForLose;
        [SerializeField] private int timeCheck = 1;
        [SerializeField] private int waitAfterEndGame = 3;
        [SerializeField] private Ball ball;
        private void Start()
        {
            ball.BallMoved += OnGameStarted;
        }
        public void OnGameStarted()
        {
            StartCoroutine(CheskLose());
        }
        IEnumerator CheskLose()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeCheck);
                if (rigidbodyPlayer.linearVelocity.z < velocityForLose && !ball.IsCanMove)
                {
                    yield return new WaitForSeconds(waitAfterEndGame);
                    EndGame?.Invoke();
                }
            }
        }
    }
}