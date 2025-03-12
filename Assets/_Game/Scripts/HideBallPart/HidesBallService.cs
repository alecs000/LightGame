using UnityEngine;

namespace Assets._Game.Scripts.HideBallPart
{
    public class HidesBallService : MonoBehaviour
    {
        [SerializeField] private Transform[] ballHideTransforms;
        [SerializeField] private BallForFind ballForFind;
        [SerializeField] private GameObject bowlingGameMainParts;

        private void Start()
        {
            HideBall();
            ballForFind.Clicked += OnHideBallCkicked;
        }

        private void HideBall()
        {
            Transform randomBallHideTransform = ballHideTransforms[Random.Range(0, ballHideTransforms.Length)];
            ballForFind.transform.position = randomBallHideTransform.position;
            ballForFind.transform.localScale = randomBallHideTransform.localScale;
        }
        private void OnHideBallCkicked()
        {
            bowlingGameMainParts.SetActive(true);
        }
    }
}