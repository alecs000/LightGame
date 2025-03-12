using Assets._Game.Scripts.Game;
using UnityEngine;

namespace Assets._Game.Scripts.Bank
{
    public class AddedCoinsOnSceneObserver : MonoBehaviour
    {
        [SerializeField] private PinObserver pinObserver;
        private int amount;
        public int Amount => amount;
        private void Start()
        {
            pinObserver.PinFallen += () => amount++;
        }

    }
}