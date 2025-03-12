using Assets._Game.Scripts.PinsLogic;
using UnityEngine;

namespace Assets._Game.Scripts.Shop.Upgrades
{
    public class UpgradePinsAmount : UpgradableItem
    {
        [SerializeField] private Transform[] positions;
        [SerializeField] private PinsGenerator pinsGenerator;

        public override void Upgrade(int level)
        {
            pinsGenerator.Clear();
            for (int i = 0; i < positions.Length; i++)
            {
                if (i <= level)
                {
                    pinsGenerator.Generate(2, positions[i].position);
                }
            }
        }

    }
}