using UnityEngine;

namespace Assets._Game.Scripts.Shop.Upgrades
{
    public abstract class UpgradableItem : MonoBehaviour
    {
        [SerializeField] private string hash;
        public string Hash => hash;
        public abstract void Upgrade(int level);
    }
}