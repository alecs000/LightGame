using Assets._Game.Scripts.Bank;
using Assets._Game.Scripts.PinsLogic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Game.Scripts.Game
{
    public class PinObserver : MonoBehaviour
    {
        public event UnityAction PinFallen;
        [SerializeField] private PinsGenerator pinsGenerator;
        [SerializeField] private CoinsService coinsService;

        private void Awake()
        {
            pinsGenerator.PinsGenerated += Initialize;
        }
        private void Initialize()
        {
            for (int i = 0; i < pinsGenerator.Pins.Count; i++)
            {
                pinsGenerator.Pins[i].Fallen = OnPinFallen;
            }
        }
        private void OnPinFallen()
        {
            PinFallen?.Invoke();
            coinsService.Add(1);
        }
    }
}