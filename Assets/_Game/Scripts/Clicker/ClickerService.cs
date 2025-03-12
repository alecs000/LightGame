using Assets._Game.Scripts.Game;
using Assets._Game.Scripts.InputLogic;
using System;
using UnityEngine;

namespace Assets._Game.Scripts.Clicker
{
    public class ClickerService : MonoBehaviour
    {
        [SerializeField] private Ball ball;
        [SerializeField] private MobileInputService mobileInputService;
        private void Start()
        {
            mobileInputService.Click += OnClick;
        }

        private void OnClick(Vector2 arg0)
        {
            ball.AddForceToMovingBall();
        }
    }
}