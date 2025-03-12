using Assets._Game.Scripts.Game;
using UnityEngine;

namespace Assets._Game.Scripts.Shop.Upgrades
{
    public class UpgradeStrength : UpgradableItem
    {
        [SerializeField] private Ball ball;
        [SerializeField] private float[] strengths;
        public override void Upgrade(int level)
        {
            ball.SetForce(strengths[level]);
        }
    }
}